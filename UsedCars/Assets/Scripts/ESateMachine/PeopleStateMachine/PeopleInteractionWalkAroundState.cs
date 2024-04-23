using UnityEngine;

public class PeopleInteractionWalkAroundState : PeopleBaseInteractionState {

    public PeopleInteractionWalkAroundState(PeopleContextState peopleContext, PeopleStateMachine.EPoepleInteractionState statekey) : base(peopleContext, statekey) {
        PeopleContextState peopleContextState = peopleContext;
    }
    private Transform currentWayPoint;
    private float speed;
    private float distanceThreeShold = 1f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private const string IS_WALKING = "IsWalking";
    public override void EnterState() {

        currentWayPoint = PeopleContext.WayPointWalkoutSide.GetChildTransfrom(currentWayPoint);
        speed = PeopleContext.GeneralSpeed;
        PeopleContext.Animator.SetBool(IS_WALKING, true);
    }

    public override void ExitState() {
    }

    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {
            if (PeopleContext.FirstReceptionChooseCar.GetClientTransform() == PeopleContext.PeopleStateMachine.transform) {
                return PeopleStateMachine.EPoepleInteractionState.FirstChooseCar;
            }
        return StateKey;
    }
    public override void UpdateState() {
        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        PeopleContext.PeopleStateMachine.transform.Translate(diretionToWayPoint * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(PeopleContext.PeopleStateMachine.transform.position, currentWayPoint.position) < distanceThreeShold) {
            currentWayPoint = PeopleContext.WayPointWalkoutSide.GetChildTransfrom(currentWayPoint);
        }
        RotateTowardsWayPoint();
    }
    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerExit(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other) {
        throw new System.NotImplementedException();
    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint);
        PeopleContext.PeopleStateMachine.transform.rotation = Quaternion.Slerp(PeopleContext.PeopleStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
