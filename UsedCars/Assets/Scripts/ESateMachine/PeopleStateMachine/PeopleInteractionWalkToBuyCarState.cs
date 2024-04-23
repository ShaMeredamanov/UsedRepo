
using UnityEngine;

public class PeopleInteractionWalkToBuyCarState : PeopleBaseInteractionState
{
    public PeopleInteractionWalkToBuyCarState(PeopleContextState peopleContextState, PeopleStateMachine.EPoepleInteractionState statekey): base(peopleContextState, statekey)
    {
        PeopleContextState peopleContext = peopleContextState;
    }
    private MoveCarSideWayPoint moveCarSideWayPoint;
    private Transform parentTransform;
    private Transform currentWayPoint;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 1f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private const string IS_WALKING = "IsWalking";
    public override void EnterState() {
        
        currentWayPoint = PeopleContext.MoveCarSideWayPoint.GetNextWayPoint(currentWayPoint);
        moveCarSideWayPoint = PeopleContext.MoveCarSideWayPoint.GetComponent<MoveCarSideWayPoint>();
        parentTransform = moveCarSideWayPoint.transform;
        childCount = parentTransform.childCount;
        speed = PeopleContext.GeneralSpeed;
        PeopleContext.Animator.SetBool(IS_WALKING, true);
        
    }

    public override void ExitState() {
    }

    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {
        //if(childCount -1 <= currentWayPoint.GetSiblingIndex()) {
        //    PeopleContext.SecondReceptionSignContract.SecondRepairShop.ClearCar();
        //}
        if(currentWayPoint.GetSiblingIndex() >= 2) {
            PeopleContext.PeopleStateMachine.EnableCollider();
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
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
            currentWayPoint = PeopleContext.MoveCarSideWayPoint.GetNextWayPoint(currentWayPoint);
        }
        RotateTowardsWayPoint();
    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint);
        PeopleContext.PeopleStateMachine.transform.rotation = Quaternion.Slerp(PeopleContext.PeopleStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
