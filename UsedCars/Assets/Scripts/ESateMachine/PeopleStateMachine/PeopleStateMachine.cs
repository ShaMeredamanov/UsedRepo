using UnityEngine;

public class PeopleStateMachine : StateManager<PeopleStateMachine.EPoepleInteractionState> {
    public enum EPoepleInteractionState {
        WalkAroundState,
        InsideInRoomState,
        BuyCarState,
        WalkCarSideState,
        SignContractState,
        FirstChooseCar,
    }

    private PeopleContextState _peopleContext;

    [SerializeField] private WaitingQueueParent _waitingQueueParent;
    [SerializeField] private FirstReceptionChooseCar _firstReception;
    [SerializeField] private SecondReceptionSignContract _secondReception;
    [SerializeField] private PeoplsWayPoint _wayPoints;
    [SerializeField] private PeopleWalkCarSideWayPoint _wayPointsSide;
    [SerializeField] private SignContractWayPoint _signContractWayPoint;
    [SerializeField] private MoveCarSideWayPoint _moveCarSideWayPoint;
    [SerializeField] private CarsParentPoint _carsParentPoint;
    [SerializeField] private Animator _animator;
    private bool getStateAgain;
    private float _generalSpeed = 40f;
    private float timer = 2f;
    private float timerMax = 2f;
    private void Awake() {
        _peopleContext = new PeopleContextState(_animator, _wayPoints, _generalSpeed, _firstReception, _secondReception,
            _wayPointsSide, _signContractWayPoint, _moveCarSideWayPoint, _carsParentPoint, _waitingQueueParent, this);
        InitializedStates();
    }
    private void InitializedStates() {
        States.Add(EPoepleInteractionState.WalkAroundState, new PeopleInteractionWalkAroundState(_peopleContext, EPoepleInteractionState.WalkAroundState));
        States.Add(EPoepleInteractionState.InsideInRoomState, new PeopleInteractionInsideInRoomState(_peopleContext, EPoepleInteractionState.InsideInRoomState));
        States.Add(EPoepleInteractionState.BuyCarState, new PeopleInteractionWalkToBuyCarState(_peopleContext, EPoepleInteractionState.BuyCarState));
        States.Add(EPoepleInteractionState.WalkCarSideState, new PeopleInteractionWalkCarSideState(_peopleContext, EPoepleInteractionState.WalkCarSideState));
        States.Add(EPoepleInteractionState.SignContractState, new PeopleInteractionSignContractState(_peopleContext, EPoepleInteractionState.SignContractState));
        States.Add(EPoepleInteractionState.FirstChooseCar, new PeopleInteractionFirstChooseCar(_peopleContext, EPoepleInteractionState.FirstChooseCar));
        CurrentState = States[EPoepleInteractionState.WalkAroundState];
    }
    public bool CheckStateIsStateInsideRoom() {
        return CurrentState == States[EPoepleInteractionState.InsideInRoomState];
    }
    public void DestroyObject() {
        Destroy(gameObject);
    }
    public bool CheckStateSignContractState() {
        return CurrentState == States[EPoepleInteractionState.SignContractState];
    }
    public FirstReceptionChooseCar ChooseCar(FirstReceptionChooseCar firstReceptionChooseCar) {
        _firstReception = firstReceptionChooseCar;
        return _firstReception;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionStateMachine)) {
            CurrentState.OnTriggerEnter(other);
        }
       
    }
    private void OnTriggerStay(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            timer -= Time.deltaTime;
            if (timer < 0) {
                CurrentState = States[EPoepleInteractionState.WalkCarSideState];
                CurrentState.EnterState();
                timer = timerMax;
                var collider = GetComponent<BoxCollider>().enabled = false;    
            }
        }
    }
    public void ChangeState() {
        CurrentState = States[EPoepleInteractionState.BuyCarState];
        CurrentState.EnterState();
    }
    public void ChangeToGetStateAgaingToTrue() {
        getStateAgain =true;
    } public void ChangeToGetStateAgaingToFalse() { 
    
        getStateAgain =false;
    }
    public bool GetStateGaing() {
        return getStateAgain;   
    }
    public void EnableCollider() {
        var collider = GetComponent<BoxCollider>().enabled = true;
    }
}

