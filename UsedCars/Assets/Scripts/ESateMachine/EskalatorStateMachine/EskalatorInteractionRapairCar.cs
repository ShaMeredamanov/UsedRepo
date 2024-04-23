using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionRapairCar : EskalatorBaseIteractionState {/// <summary>
///Constructor 
/// </summary>
/// <param name="context"></param>
/// <param name="estate"></param>
    public EskalatorInteractionRapairCar(EskalatorContextState context, EskalatorInteractionStateMachine.EEskalatorInteractionState estate) : base(context, estate) {
        EskalatorContextState Context = context;
    }
    /// <summary>
    /// At the moment i just put second when i get crash car i changed it with crash car after chnage state
    /// </summary>
    /// 
    private Transform repaiCarWayPointTransform;
    private ReparingWaypoint.ReapirCarWayPoints _reapirCarWayPoints;
    private Transform currentWayPoint;
    private Transform parentTransfrorm;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 2.5f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    public override void EnterState() {
        repaiCarWayPointTransform = EskalatorContext.FirstCarRepairWayPointParent.GetNExtQueue(EskalatorContext.EskalatorStateMachine,repaiCarWayPointTransform);
        _reapirCarWayPoints = repaiCarWayPointTransform.GetComponent<ReparingWaypoint.ReapirCarWayPoints>();
        currentWayPoint = _reapirCarWayPoints.GetNextWayPoint(currentWayPoint);
        parentTransfrorm = _reapirCarWayPoints.GetThisComponentTransfrom(parentTransfrorm);
        childCount = parentTransfrorm.childCount;
        speed = EskalatorContext.GeneralSpeed;

    }

    public override void ExitState() {
    }

    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState() {
        //if (childCount - 1 <= currentWayPoint.GetSiblingIndex()) {
        //    if (!EskalatorContext.FirstRepairSHop.HasCar()) {
        //        EskalatorContext.InGarage.GetCarObject().ChangeDurtyCarToWHiteCar();
        //        return EskalatorInteractionStateMachine.EEskalatorInteractionState.SecondReapairShop;
        //    }
        //}
        if (EskalatorContext.EskalatorStateMachine.GetWayPointAgain()) {
            repaiCarWayPointTransform = EskalatorContext.FirstCarRepairWayPointParent.GetFreeWayPoint(EskalatorContext.EskalatorStateMachine, repaiCarWayPointTransform);
            _reapirCarWayPoints = repaiCarWayPointTransform.GetComponent<ReparingWaypoint.ReapirCarWayPoints>();
            currentWayPoint = _reapirCarWayPoints.GetNextWayPoint(currentWayPoint);
            parentTransfrorm = _reapirCarWayPoints.GetThisComponentTransfrom(parentTransfrorm);
            childCount = parentTransfrorm.childCount;
            EskalatorContext.EskalatorStateMachine.GetWayPointAgainToFalse();
            speed = 80f;
        }
        return StateKey;
    }

    public override void UpdateState() {
        var direction = (currentWayPoint.transform.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        EskalatorContext.EskalatorStateMachine.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(EskalatorContext.EskalatorStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            currentWayPoint = _reapirCarWayPoints.GetNextWayPoint(currentWayPoint);
        }
        if (Vector3.Distance(EskalatorContext.EskalatorStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            speed = 0;
        } else {
            speed = 80;
        }
        //  RotateTowardsWayPoint();
    }

    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerStay(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other) {
        throw new System.NotImplementedException();
    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(-diretionToWayPoint);
        EskalatorContext.EskalatorStateMachine.transform.rotation = Quaternion.Slerp(EskalatorContext.EskalatorStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
