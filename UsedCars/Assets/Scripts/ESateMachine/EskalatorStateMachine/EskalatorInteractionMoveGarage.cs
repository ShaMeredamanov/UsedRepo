using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionMoveGarage : EskalatorBaseIteractionState
{
    public EskalatorInteractionMoveGarage(EskalatorContextState context, EskalatorInteractionStateMachine.EEskalatorInteractionState estate): base(context, estate)
    {
        EskalatorContextState Context = context; 
    }

    private Transform currentWayPoint;
    private float speed;
    private float distanceThreeShold = 0.5f;
    private Quaternion rotataionGoal;
    private Vector3 directionToWoyPoint;
    private float rotateSpeed = 5f;
    private Transform parentTransfrom;
    private int childCount;
    public override void EnterState()
    {

        currentWayPoint = EskalatorContext.FirstWayPoints.GetNextWayPoint(currentWayPoint);
        parentTransfrom = EskalatorContext.FirstWayPoints.GetThisComponentTransfrom(parentTransfrom);
        childCount = parentTransfrom.childCount;
        speed = EskalatorContext.GeneralSpeed;
    }
    public override void ExitState()
    {
    }
    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState()
    {
        if(childCount -1 <= currentWayPoint.GetSiblingIndex())
        {
            return EskalatorInteractionStateMachine.EEskalatorInteractionState.RepairState;
        }
        return StateKey;
    }
    public override void UpdateState()
    {
        var direction = (currentWayPoint.transform.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        EskalatorContext.EskalatorStateMachine.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(EskalatorContext.EskalatorStateMachine.transform.position, currentWayPoint.position) < distanceThreeShold)
        {
            currentWayPoint = EskalatorContext.FirstWayPoints.GetNextWayPoint(currentWayPoint);
        }
        RotateTowardsWayPoint();
    }
    private void RotateTowardsWayPoint()
    {
        directionToWoyPoint = (currentWayPoint.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        rotataionGoal = Quaternion.LookRotation(directionToWoyPoint);
        EskalatorContext.EskalatorStateMachine.transform.rotation = Quaternion.Slerp(EskalatorContext.EskalatorStateMachine.transform.rotation, rotataionGoal, rotateSpeed * Time.deltaTime);
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
