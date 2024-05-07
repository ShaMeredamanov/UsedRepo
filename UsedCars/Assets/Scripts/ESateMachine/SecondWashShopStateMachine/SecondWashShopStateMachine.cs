using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondWashShopStateMachine : StateManager<SecondWashShopStateMachine.ESecondWashShopInteraction> {
    public enum ESecondWashShopInteraction {
        FillState,
        WithoutWorker,
        WaitExitCar,
    }

    private SecondWashShopContextState SecondWashShopContextStates;

    [SerializeField] private List<EskalatorInteractionStateMachine> _eskalatorInteractionStateMachines;
    [SerializeField] private FirstRepairShopInteractionStateMachine _firstRepairShopSTateMachine;
    [SerializeField] private SecondReceptionSignContract _secondSignContract;
    [SerializeField] private ThirdWayPointParentForQueue _thirdWayPointParentForQueue;
    [SerializeField] private Image _image;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ParticleSystem _particleSecond;
    [SerializeField] private ParticleSystem _buubleShower;
    [SerializeField] private Animator _animator;
    [SerializeField] private FemaleCashier _cashier;
    [SerializeField] private SignContractInteractionStateMachine _signContractInteractionStateMachine;
    [SerializeField] private Animator _workerAnimator;
    [SerializeField] private Image _outLine;
    private PlayerDjoystick _playerDjoystick;
    private EskalatorInteractionStateMachine _eskalatorInteractionStateMachine;

    private float timer;
    private float upgrade;
    private void Awake() {
        timer = 5f;
        upgrade = timer / 100;
        _eskalatorInteractionStateMachines = new List<EskalatorInteractionStateMachine>();
        SecondWashShopContextStates = new SecondWashShopContextState(_eskalatorInteractionStateMachines,
            this, _firstRepairShopSTateMachine, _secondSignContract, _thirdWayPointParentForQueue, _image, 
            _particleSystem, _particleSecond, _animator, 
            _signContractInteractionStateMachine, _buubleShower, _workerAnimator, _outLine);
        InitilizeStates();
    }
    private void InitilizeStates() {
        States.Add(ESecondWashShopInteraction.FillState, new SecondWashShopInteractionFillState(SecondWashShopContextStates, ESecondWashShopInteraction.FillState));
        States.Add(ESecondWashShopInteraction.WithoutWorker, new SecondWashShopInteractionWithoutWorker(SecondWashShopContextStates, ESecondWashShopInteraction.WithoutWorker));
        States.Add(ESecondWashShopInteraction.WaitExitCar, new SecondWashShopInteractionWaitCarExit(SecondWashShopContextStates, ESecondWashShopInteraction.WaitExitCar));
        CurrentState = States[ESecondWashShopInteraction.WithoutWorker];
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = playerDjoystick;
        }
        if(other.TryGetComponent<FemaleCashier>(out var femaleCashier)) {
            _cashier = femaleCashier;
        }

    }
    private void OnTriggerStay(Collider other) {
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionStateMachine)) {
            if(_cashier != null) {
                CurrentState.OnTriggerStay(other);
            }else if (_playerDjoystick != null) {
                CurrentState.OnTriggerStay(other);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        _playerDjoystick = null;
        if(other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionStateMachine)) {
            CurrentState.OnTriggerExit(other);  
        }
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            if (_cashier == null) {
                CurrentState.OnTriggerExit(other);
            }
        }
    }
    public void ChangeStates() {
        CurrentState = States[ESecondWashShopInteraction.FillState];
        CurrentState.EnterState();
    }
    public void GetEskalatorToList(EskalatorInteractionStateMachine eskalatorInteractionState) {
        _eskalatorInteractionStateMachines.Add(eskalatorInteractionState);
    }
    public void RemoveFromList() {
        _eskalatorInteractionStateMachines.RemoveAt(0);
        _thirdWayPointParentForQueue.DecrementIndex();
        //foreach (EskalatorInteractionStateMachine eskalatorInteractionState in _eskalatorStateMachineList) {
        //    eskalatorInteractionState.GetWayPointAgainToTrue();
        //}
    }
   public void ChangeUpgradeAndTimer(float timer) {
        this.timer -= timer;
        upgrade = this.timer / 100;
    }
    public float Timer => this.timer;
    public float Upgrade => upgrade;   
    public List<EskalatorInteractionStateMachine> EskalatorInteractionStateMachinesList => _eskalatorInteractionStateMachines;
}