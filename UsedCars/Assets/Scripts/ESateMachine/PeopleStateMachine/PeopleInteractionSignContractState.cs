
using UnityEngine;

public class PeopleInteractionSignContractState : PeopleBaseInteractionState {
    public PeopleInteractionSignContractState(PeopleContextState peopleContext, PeopleStateMachine.EPoepleInteractionState statekey) : base(peopleContext, statekey) {
        PeopleContextState peopleContextState = peopleContext;
    }
    private WaitingQueueParent waitingQueue;
    private SignContractWayPoint signContractWayPoint;
    private Transform parentTransform;
    private Transform _parentTransform;
    private Transform currentWayPoint;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 5f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private const string IS_WALKING = "IsWalking";
    private Animator _animator;
    public override void EnterState() {
        waitingQueue = PeopleContext.WaitingQueueParent;
        parentTransform = waitingQueue.GetCurrentQueue(parentTransform, PeopleContext.PeopleStateMachine);
        signContractWayPoint = parentTransform.GetComponent<SignContractWayPoint>();
        currentWayPoint = signContractWayPoint.GetNextWayPoint(currentWayPoint);
        _parentTransform = signContractWayPoint.GetThisComponentTransfrom(_parentTransform);
        speed = PeopleContext.GeneralSpeed;
        _animator = PeopleContext.Animator;
        _animator.SetBool(IS_WALKING, true);
        childCount = _parentTransform.childCount;
    }
    public override void ExitState() {
    }
    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {
        if (PeopleContext.PeopleStateMachine.GetStateGaing()) {
            parentTransform = waitingQueue.GetWayPoint(PeopleContext.PeopleStateMachine, parentTransform);
            signContractWayPoint = parentTransform.GetComponent<SignContractWayPoint>();
            currentWayPoint = signContractWayPoint.GetNextWayPoint(currentWayPoint);
            childCount = _parentTransform.childCount;
            speed = 40f;
            _animator.SetBool(IS_WALKING, true);
            PeopleContext.PeopleStateMachine.ChangeToGetStateAgaingToFalse();
        } else {
            if (childCount < currentWayPoint.GetSiblingIndex()) {
                // speed = 40f;
                _animator.SetBool(IS_WALKING, false);
            }
        }
        //if (PeopleContext.SecondReceptionSignContract.HasPlayer()) {
        //    timer -= Time.deltaTime;
        //    if (timer < 0) {
        //        PeopleContext.SecondReceptionSignContract.ClearClient();
        //        return PeopleStateMachine.EPoepleInteractionState.BuyCarState;
        //    }
        //}
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
            currentWayPoint = signContractWayPoint.GetNextWayPoint(currentWayPoint);
            if (Vector3.Distance(PeopleContext.PeopleStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
                _animator.SetBool(IS_WALKING, false);
                speed = 0;
            } else {
                _animator.SetBool(IS_WALKING, false);
                speed = 0;
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