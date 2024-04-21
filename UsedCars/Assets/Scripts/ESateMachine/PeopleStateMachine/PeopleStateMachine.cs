using System.Collections;
using System.Collections.Generic;
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


    [SerializeField] private FirstReceptionChooseCar _firstReception;
    [SerializeField] private SecondReceptionSignContract _secondReception;
    [SerializeField] private PeoplsWayPoint _wayPoints;
    [SerializeField] private PeopleWalkCarSideWayPoint _wayPointsSide;
    [SerializeField] private SignContractWayPoint _signContractWayPoint;
    [SerializeField] private MoveCarSideWayPoint _moveCarSideWayPoint;
    [SerializeField] private CarsParentPoint _carsParentPoint;
    [SerializeField] private Animator _animator;
    private float _generalSpeed = 40f;
    private void Awake() {
        _peopleContext = new PeopleContextState(_animator, _wayPoints, _generalSpeed, _firstReception, _secondReception, _wayPointsSide, _signContractWayPoint, _moveCarSideWayPoint, _carsParentPoint, this);
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
}

