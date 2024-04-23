using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleContextState {
    private Animator _animator;
    private PeoplsWayPoint _waypointWalkOutSide;
    private SignContractWayPoint _signContractWayPoint;
    private FirstReceptionChooseCar _firstReceptionChooseCar;
    private SecondReceptionSignContract _secondReceptionSignContract;
    private PeopleStateMachine _peopleStateMachine;
    private PeopleWalkCarSideWayPoint _waypointWalkOutSideWayPoint;
    private CarsParentPoint _carsParentPoint;
    private MoveCarSideWayPoint _moveCarSide;
    private WaitingQueueParent _waitingQueueParent;
    private float _generalSpeed;

    public PeopleContextState(Animator animator, PeoplsWayPoint waypointWalkOutSide, float generalSpeed,
        FirstReceptionChooseCar firstReceptionChooseCar, SecondReceptionSignContract secondReceptionSignContract,
        PeopleWalkCarSideWayPoint peopleWalkCarSideWayPoint, SignContractWayPoint signContractWayPoint, MoveCarSideWayPoint moveCarSide,
        CarsParentPoint carsParentPoint, WaitingQueueParent waitingQueueParent, PeopleStateMachine peopleStateMachine) {
        _animator = animator;
        _waypointWalkOutSide = waypointWalkOutSide;
        _generalSpeed = generalSpeed;
        _peopleStateMachine = peopleStateMachine;
        _firstReceptionChooseCar = firstReceptionChooseCar;
        _secondReceptionSignContract = secondReceptionSignContract;
        _waypointWalkOutSideWayPoint = peopleWalkCarSideWayPoint;
        _signContractWayPoint = signContractWayPoint;
        _moveCarSide = moveCarSide;
        _carsParentPoint = carsParentPoint;
        _waitingQueueParent = waitingQueueParent;
    }
    /// <summary>
    /// Read Only properties
    /// </summary>
    public Animator Animator => _animator;
    public PeoplsWayPoint WayPointWalkoutSide => _waypointWalkOutSide;
    public PeopleStateMachine PeopleStateMachine => _peopleStateMachine;
    public float GeneralSpeed => _generalSpeed;
    public FirstReceptionChooseCar FirstReceptionChooseCar => _firstReceptionChooseCar;
    public SecondReceptionSignContract SecondReceptionSignContract => _secondReceptionSignContract;
    public PeopleWalkCarSideWayPoint PeopleWalkCarSideWayPoint => _waypointWalkOutSideWayPoint;
    public SignContractWayPoint SignContractWayPoint => _signContractWayPoint;
    public MoveCarSideWayPoint MoveCarSideWayPoint => _moveCarSide;
    public CarsParentPoint CarsParentPoint => _carsParentPoint;
    public WaitingQueueParent WaitingQueueParent => _waitingQueueParent;
}

