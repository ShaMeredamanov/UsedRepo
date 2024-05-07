using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FirstRepairShopInteractionStateMachine : StateManager<FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions> {

    public enum EFirstRepairShopIntersctions {
        WithWorker,
        FillState,
        WIthoutWorker,
    }
    private FirstRepairShopContext _repairShopContext;

    [SerializeField] private List<EskalatorInteractionStateMachine> _eskalatorInteractionStateMachinesList;
    [SerializeField] private FirstCarRepairWayPointParent _firstCarRepairWayPointParent;
    [SerializeField] private SecondRepairShop _secondRepairShop;
    [SerializeField] private TransporterInGarage _transporterInGarage;
    [SerializeField] private Image _image;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Animator _animator;
    [SerializeField] private FemaleCashier _cashier;
    [SerializeField] private SecondWashShopStateMachine _secondWashShopStateMachine;
    [SerializeField] private Animator _workerAnimator;
    [SerializeField] private Image _outLine;
    private EskalatorInteractionStateMachine stateMachineEskalator;

    private float timer;
    private float upgradeTimer;
    private PlayerDjoystick _playerDjoystick;
    private void Awake() {
        timer = 5f;
        upgradeTimer = timer / 100;
        _eskalatorInteractionStateMachinesList = new List<EskalatorInteractionStateMachine>();
        _repairShopContext = new FirstRepairShopContext(_eskalatorInteractionStateMachinesList, _transporterInGarage,
            _secondRepairShop, this, _image, _particleSystem, _animator, _secondWashShopStateMachine, _workerAnimator,
            _outLine);
        InitilizeStates();
        _particleSystem.Stop();
    }
    private void InitilizeStates() {
        States.Add(EFirstRepairShopIntersctions.WIthoutWorker, new FirstRepairShopInteractionWithOutWorker(_repairShopContext, EFirstRepairShopIntersctions.WIthoutWorker));
        States.Add(EFirstRepairShopIntersctions.FillState, new FirstRepairShopInteractionFillState(_repairShopContext, EFirstRepairShopIntersctions.FillState));
        //  States.Add(EFirstRepairShopIntersctions.WithWorker, new FirstRepairShopInteractionWithWorker(_repairShopContext, EFirstRepairShopIntersctions.WithWorker));
        CurrentState = States[EFirstRepairShopIntersctions.WIthoutWorker];
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = other.GetComponent<PlayerDjoystick>();
        }
        if (other.TryGetComponent<FemaleCashier>(out var femaleCashier)) {
            _cashier = femaleCashier;
        }
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionStateMachine)) {
            CurrentState.OnTriggerEnter(other);
        }
    }
    private void OnTriggerStay(Collider other) {

        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var component)) {
            if (_cashier != null) {
                CurrentState.OnTriggerStay(other);
            } else if (_playerDjoystick != null) {
                CurrentState.OnTriggerStay(other);
            }
        }

    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            if (_cashier == null) {
                CurrentState.OnTriggerExit(other);
                _playerDjoystick = null;
            }
        }
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionStateMachine)) {
            //   RemoveFromEsklatorList(other.GetComponent<EskalatorInteractionStateMachine>());
        }
    }
    public void TransporterIngarage(TransporterInGarage transporterInGarage) {
        EskalatorInteractionStateMachine eskaltorStateMachine = transporterInGarage.StateMachineEskaltor();
        GetEsKalatorINteractionStateMachine(eskaltorStateMachine);
    }
    private void GetEsKalatorINteractionStateMachine(EskalatorInteractionStateMachine eskalatorInteractionStateMachine) {
        stateMachineEskalator = eskalatorInteractionStateMachine;
        _eskalatorInteractionStateMachinesList.Add(stateMachineEskalator);
    }
    public void RemoveFromEsklatorList(EskalatorInteractionStateMachine eskalatorInteractionStateMachine) {
        var index = _eskalatorInteractionStateMachinesList.IndexOf(eskalatorInteractionStateMachine);
        _eskalatorInteractionStateMachinesList.RemoveAt(index);
        _firstCarRepairWayPointParent.DecrementIndex(eskalatorInteractionStateMachine);
        foreach (EskalatorInteractionStateMachine eskalatorInteractionState in _eskalatorInteractionStateMachinesList) {
            eskalatorInteractionState.GetWayPointAgainToTrue();
        }
    }

    public void ChangeStateToFillSTate() {
        CurrentState = States[EFirstRepairShopIntersctions.FillState];
        CurrentState.EnterState();
    }
    public void ChangeTimerAndUpgrade(float timer) {
        this.timer -= timer;
        upgradeTimer = this.timer / 100f;
    }
    public float Timer => this.timer;
    public float UpgardeTimer => upgradeTimer;
    public EskalatorInteractionStateMachine EskalatorInteractionStateMachine => stateMachineEskalator;

}
