using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInteractionFirstChooseCar : PeopleBaseInteractionState {

    public PeopleInteractionFirstChooseCar(PeopleContextState peopleContext, PeopleStateMachine.EPoepleInteractionState state) : base(peopleContext, state) {

        PeopleContextState peopleContextState = peopleContext;
    }

    private Transform walkingWayPointParentTransform;
    private CarsParentPoint _carsParentPoint;
    private WayPointForCars _wayPointForCars;
    private Transform currentCarsWayPoint;
    private Transform currentWayPoint;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 1f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float timer = 3f;
    private float timerMax = 3f;
    private float rotateSpeed = 10f;
    private const string IS_WALKING = "IsWalking";
    public override void EnterState() {

        currentCarsWayPoint = PeopleContext.CarsParentPoint.GetCurrentCarsWayPoint(currentCarsWayPoint);
        _wayPointForCars = currentCarsWayPoint.GetComponent<WayPointForCars>();
        _wayPointForCars.GetPeopleStateMachine(PeopleContext.PeopleStateMachine);
        walkingWayPointParentTransform = _wayPointForCars.GetWayPointForCarsTransform(walkingWayPointParentTransform);
        childCount = walkingWayPointParentTransform.childCount;
        currentWayPoint = _wayPointForCars.GetNextWayPoint(currentWayPoint);
        speed = PeopleContext.GeneralSpeed;
        PeopleContext.Animator.SetBool(IS_WALKING, true);
    }

    public override void ExitState() {
    }

    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex()) {
            speed = 0;
            PeopleContext.Animator.SetBool(IS_WALKING, false);
            timer -= Time.deltaTime;
            if (timer <= 0) {
                timer = timerMax;
                return PeopleStateMachine.EPoepleInteractionState.WalkCarSideState;
            }
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerExit(Collider other) {
    }

    public override void OnTriggerStay(Collider other) {
    }

    public override void UpdateState() {
        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        PeopleContext.PeopleStateMachine.transform.Translate(diretionToWayPoint * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(PeopleContext.PeopleStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            if (childCount - 1 > currentWayPoint.GetSiblingIndex()) {
                currentWayPoint = _wayPointForCars.GetNextWayPoint(currentWayPoint);
            }
        }
        RotateTowardsWayPoint();
    }

    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint);
        PeopleContext.PeopleStateMachine.transform.rotation = Quaternion.Slerp(PeopleContext.PeopleStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
