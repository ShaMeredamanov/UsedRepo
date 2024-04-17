using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PeopleInteractionWalkCarSideState : PeopleBaseInteractionState {

    public PeopleInteractionWalkCarSideState(PeopleContextState peopleContext, PeopleStateMachine.EPoepleInteractionState statekey) : base(peopleContext, statekey) {

        PeopleContextState peopleContextState = peopleContext;
    }

    private PeopleWalkCarSideWayPoint peopleWalkCarSide;
    private Transform currentWayPoint;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 1f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private const string IS_WALKING = "IsWalking";
    private Transform parentTransform;
    public override void EnterState() {
        currentWayPoint = PeopleContext.PeopleWalkCarSideWayPoint.GetNextWayPoint(currentWayPoint);
        peopleWalkCarSide = PeopleContext.WayPointWalkoutSide.GetComponent<PeopleWalkCarSideWayPoint>();
        parentTransform = PeopleContext.PeopleWalkCarSideWayPoint.GetThisComponentTransfrom(parentTransform);
        speed = PeopleContext.GeneralSpeed;
        childCount = parentTransform.childCount;
        PeopleContext.Animator.SetBool(IS_WALKING, true);
    }

    public override void ExitState() {
    }

    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {

        if (childCount - 1 <= currentWayPoint.GetSiblingIndex()) {
            PeopleContext.FirstReceptionChooseCar.EnableCapsuleColliderComponent();
            return PeopleStateMachine.EPoepleInteractionState.InsideInRoomState;

        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void UpdateState() {

        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        PeopleContext.PeopleStateMachine.transform.Translate(diretionToWayPoint * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(PeopleContext.PeopleStateMachine.transform.position, currentWayPoint.position) < distanceThreeShold) {
            currentWayPoint = PeopleContext.PeopleWalkCarSideWayPoint.GetNextWayPoint(currentWayPoint);
        }
        RotateTowardsWayPoint();
    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint);
        PeopleContext.PeopleStateMachine.transform.rotation = Quaternion.Slerp(PeopleContext.PeopleStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
