using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptionChooseCarStateMachine : StateManager<ReceptionChooseCarStateMachine.EFirstReceptionStateMachine> {
    public enum EFirstReceptionStateMachine {
        WithoutWorker,
        WithWorker,
        FillState,
    }
    private ReceptionChooseCarContextState ReceptionContext;

    [SerializeField] private List<PeopleStateMachine> _clientsWalkOutSideList;
    [SerializeField] private List<PeopleStateMachine> _receptionClientsList;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private Image _image;
    [SerializeField] private TransportIntercationStateMachine _intercationStateMachine;
    [SerializeField] private WaitingQueueParent _waitingQueueParent;
    [SerializeField] private SignContractInteractionStateMachine _signContractInteractionStateMachine;
    [SerializeField] private FemaleCashier _femaleCashier;
    [SerializeField] private Animator _animator;
    [SerializeField] private float upgradePrice;
    private float timer;
    private float timerMax;
    private PlayerDjoystick _playerDjoystick;

    private void Awake() {
        Application.targetFrameRate = 60;
        timer = 5f;
        upgradePrice = timer / 100;
        timerMax = 5f;
        ReceptionContext = new ReceptionChooseCarContextState(this, _clientsWalkOutSideList, _collider,
            _receptionClientsList, _image, _waitingQueueParent, _signContractInteractionStateMachine, _animator, upgradePrice);
        InitilizeStates();
        GetCleint();
    }
    private void InitilizeStates() {
        States.Add(EFirstReceptionStateMachine.WithoutWorker, new ReseptionChooseCarInteractionWithoutWorker(ReceptionContext, EFirstReceptionStateMachine.WithoutWorker));
        States.Add(EFirstReceptionStateMachine.FillState, new ReceptionChooseCarInteractionFillState(ReceptionContext, EFirstReceptionStateMachine.FillState));
        States.Add(EFirstReceptionStateMachine.WithWorker, new ReceptionChooseCarInteractionWithWorker(ReceptionContext, EFirstReceptionStateMachine.WithWorker));
        CurrentState = States[EFirstReceptionStateMachine.WithoutWorker];
    }
    public void GetCleint() {
        _receptionClientsList.Add(_clientsWalkOutSideList[0]);
        _clientsWalkOutSideList.RemoveAt(0);
        _receptionClientsList[0].SetReceptionChooseCarStateMachione(this);
    }
    public void RemoveClient() {
        _signContractInteractionStateMachine.GetClient(_receptionClientsList[0]);
        _receptionClientsList.RemoveAt(0);
    }
    private bool IsListNotNull() {
        return _receptionClientsList.Count > 0;
    }
    private void OnTriggerEnter(Collider other) {

        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = playerDjoystick;
        }
        if (other.TryGetComponent<FemaleCashier>(out var femaleCashier)) {
            _femaleCashier = femaleCashier;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (_femaleCashier != null) {
            if (IsListNotNull()) {
                CurrentState.OnTriggerStay(other);
            }
        } else if (_playerDjoystick != null) {
            if (IsListNotNull()) {
                CurrentState.OnTriggerStay(other);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (_femaleCashier != null) {
        } else if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = null;
            CurrentState.OnTriggerExit(other);
            Debug.Log("player exit");
        }
    }
    public void EnableCollider() {
        _collider.enabled = true;
    }
    public TransportIntercationStateMachine TransportIntercationStateMachine() {
        return _intercationStateMachine;
    }
    public void ChangeUpgradePriceAndTimer(float timer) {
        this.timer -= timer;
        this.timerMax -= timer;
        upgradePrice = this.timer / 100;
    }
    public float Timer => timer;
    public float TimerMax => timerMax;
    public float UpgradePrice => upgradePrice;
    public List<PeopleStateMachine> PeopleStateMachinesList => _receptionClientsList;
}
