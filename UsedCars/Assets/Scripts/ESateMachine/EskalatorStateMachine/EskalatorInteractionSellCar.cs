using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionSellCar : EskalatorBaseIteractionState {
    public EskalatorInteractionSellCar(EskalatorContextState context, EskalatorInteractionStateMachine.EEskalatorInteractionState estate) : base(context, estate) {
        EskalatorContextState Context = context;
    }
    private Transform currentWayPoint;
    private Transform parentTransfrorm;
    private Transform parentRepairWayPoint;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 2.5f;
    private int index;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private float timer = 5f;
    private float timerMax = 5f;
    private bool isPeopleBuyed;
    public override void EnterState() {
        currentWayPoint = EskalatorContext.ReparingCarWayPointsThirdCellCar.GetNextWayPoint(currentWayPoint);
        parentTransfrorm = EskalatorContext.ReparingCarWayPointsThirdCellCar.GetThisComponentTransfrom(parentTransfrorm);
        childCount = parentTransfrorm.childCount;
        speed = EskalatorContext.GeneralSpeed;
        isPeopleBuyed = false;
    }

    public override void ExitState() {
    }

    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState() {
        if (childCount - 3 <= currentWayPoint.GetSiblingIndex()) {
            if (isPeopleBuyed) {
                speed = EskalatorContext.GeneralSpeed;
            } else {
                speed = 0;
            }
        }
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex()) {
            EskalatorContext.EskalatorStateMachine.Destroy();
        }

        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)) {
            peopleStateMachine.DestroyObject();
            isPeopleBuyed = true;
        }
    }

    public override void OnTriggerExit(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void UpdateState() {
        var direction = (currentWayPoint.transform.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        EskalatorContext.EskalatorStateMachine.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(EskalatorContext.EskalatorStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            currentWayPoint = EskalatorContext.ReparingCarWayPointsThirdCellCar.GetNextWayPoint(currentWayPoint);
        }


    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint - new Vector3(90, 0, 0));
        EskalatorContext.EskalatorStateMachine.transform.rotation = Quaternion.Slerp(EskalatorContext.EskalatorStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
