using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignContractInteractionStateMachine : StateManager<SignContractInteractionStateMachine.ESignContractInteraction> {

    public enum ESignContractInteraction {
        WithoutWorker,
        FillState,
        WithWorker,
    }

    private SignContractContextState SignContractContext;


    [SerializeField] private List<PeopleStateMachine> _peopelStateMachineList;
    [SerializeField] private List<EskalatorInteractionStateMachine> _eskalatorStateMachineList;
    [SerializeField] private WaitingQueueParent _waitingQueueParent;
    [SerializeField] private FemaleCashier _femaleCashier;
    [SerializeField] private Image _image;
    [SerializeField] private UiCanvas _uiCanvas;
    [SerializeField] private Animator _workerAnimator;
    [SerializeField] private List<GameObject> _moneyObjectList;
    [SerializeField] private Image _moneyInScene;
    private PlayerDjoystick _playerDjoystick;
    private float timer;
    private float upgrade;

    private void Awake() {
        timer = 5f;
        upgrade = timer / 100f;
        SignContractContext = new SignContractContextState(this, _peopelStateMachineList, _eskalatorStateMachineList,
            _waitingQueueParent, _image, _uiCanvas, _workerAnimator, _moneyObjectList, _moneyInScene);
        InitilizeStates();
    }
    private void InitilizeStates() {
        States.Add(ESignContractInteraction.WithoutWorker, new SignContractInteractionWithoutWorker(SignContractContext, ESignContractInteraction.WithoutWorker));
        States.Add(ESignContractInteraction.WithWorker, new SignContractInteractionWithWorkerState(SignContractContext, ESignContractInteraction.WithWorker));
        States.Add(ESignContractInteraction.FillState, new SignContractInteractionFillState(SignContractContext, ESignContractInteraction.FillState));
        CurrentState = States[ESignContractInteraction.WithoutWorker];
    }
    private void OnTriggerEnter(Collider other) {


        if (other.TryGetComponent<FemaleCashier>(out var femaleCashier)) {
            _femaleCashier = femaleCashier;
        } else if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = playerDjoystick;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (_femaleCashier != null) {
            CurrentState.OnTriggerStay(other);
        } else if (_playerDjoystick != null) {
            CurrentState.OnTriggerStay(other);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (_femaleCashier != null) {
            CurrentState.OnTriggerExit(other);
        } else if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = null;
            CurrentState.OnTriggerExit(other);
        }
    }
    public void GetClient(PeopleStateMachine peopleStateMachine) {
        _peopelStateMachineList.Add(peopleStateMachine);
    }
    public void ClearAndRemoveClient() {
        _waitingQueueParent.DecrementIndex(_peopelStateMachineList[0]);
        _peopelStateMachineList.RemoveAt(0);
    }

    public void GetEsklatorInteractionStateMachineToList(EskalatorInteractionStateMachine eskalatorInteractionStateMachine) {
        _eskalatorStateMachineList.Add(eskalatorInteractionStateMachine);
    }
    public void RemoveClearFromEskaltorInteractionStateMachineList() {
        _eskalatorStateMachineList.RemoveAt(0);
    }
    public void ChnageUpgradeAndTimer(float timer) {
        this.timer -= timer;
        upgrade = timer / 100;
    }
    public float Timer => this.timer;
    public float Upgrade => this.upgrade;
    public List<EskalatorInteractionStateMachine> EskalatorInteractionStateMachinesList => _eskalatorStateMachineList;
}
