using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesAgentInteractionVacand : SalesAgentBaseState {
    public SalesAgentInteractionVacand(SalesAgentContextState salesAgentContextState, SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine statekey) : base(salesAgentContextState, statekey) {
        SalesAgentContextState salesAgentContext = salesAgentContextState;
    }

    private const string IS_WALKING = "IsWalking";

    private Transform repairCarWayPointsTransform;
    private Transform currentWayPoint;
    private Transform parentTransfrorm;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 2.5f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private bool goToTalkClent;
    public override void EnterState() {
        currentWayPoint = SalesAgentContext.SalesAgentWayPointParent.GetNextWayPoint(currentWayPoint);
        parentTransfrorm = SalesAgentContext.SalesAgentWayPointParent.GetThisComponentTransform(parentTransfrorm);
        childCount = parentTransfrorm.childCount;
        speed = 30f;
        SalesAgentContext.SalesAgentAnimator.SetBool(IS_WALKING, true);
        goToTalkClent = false;
        PeopleInteractionFirstChooseCar.OnBuyerChooseCar += ChoosedCar;
    }

    public override void ExitState() {
    }

    public override SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine GetNextState() {
        if (goToTalkClent) {
            goToTalkClent = false;
            return SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine.TalkWithClent;
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
        var direction = (currentWayPoint.transform.position - SalesAgentContext.SalesAgentStateMachine.transform.position).normalized;
        SalesAgentContext.SalesAgentStateMachine.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex()) {
            speed = 0;
            SalesAgentContext.SalesAgentAnimator.SetBool(IS_WALKING, false);
        } else if (Vector3.Distance(SalesAgentContext.SalesAgentStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            currentWayPoint = SalesAgentContext.SalesAgentWayPointParent.GetNextWayPoint(currentWayPoint);
            speed = 30f;
            SalesAgentContext.SalesAgentAnimator.SetBool(IS_WALKING, true);
        }
        RotateTowardsWayPoint();
    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - SalesAgentContext.SalesAgentStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint);
        SalesAgentContext.SalesAgentStateMachine.transform.rotation = Quaternion.Slerp(SalesAgentContext.SalesAgentStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
    private void ChoosedCar() {
        goToTalkClent = true;
    }
}