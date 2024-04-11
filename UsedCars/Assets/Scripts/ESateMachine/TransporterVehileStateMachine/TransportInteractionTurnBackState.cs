using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportInteractionTurnBackState : CarBaseInteractionState
{
    private Transform currentWayPoint;
    private float speed;
    private float distanceThreeShold = 0.5f;
    private Quaternion rotataionGoal;
    private Vector3 directionToWoyPoint;
    private float rotateSpeed = 5f;
    private Transform parentTransfrom;
    private int childCount;
    public TransportInteractionTurnBackState(TransportCarContextState context, TransportIntercationStateMachine.ETransportInteractionState estate) : base(context, estate)
    {
        TransportCarContextState Context = context;
    }
    public override void EnterState()
    {
        currentWayPoint = Context.TurnBack.GetNextWayPoint(currentWayPoint);
        parentTransfrom = Context.TurnBack.GetThisComponentTransfrom(parentTransfrom);
        childCount = parentTransfrom.childCount;
        speed = Context.GeneralSpeed;
    }
    public override void ExitState()
    {
    }
    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState()
    {
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex())
        {
            return TransportIntercationStateMachine.ETransportInteractionState.BringCar;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        var direction = (currentWayPoint.transform.position - Context.BigCar.transform.position).normalized;
        Context.BigCar.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(Context.BigCar.transform.position, currentWayPoint.position) < distanceThreeShold)
        {
            currentWayPoint = Context.TurnBack.GetNextWayPoint(currentWayPoint);

        }
        RotateTowardsWayPoint();
    }
    private void RotateTowardsWayPoint()
    {
        directionToWoyPoint = (currentWayPoint.position - Context.BigCar.transform.position).normalized;
        rotataionGoal = Quaternion.LookRotation(directionToWoyPoint);
        Context.BigCar.transform.rotation = Quaternion.Slerp(Context.BigCar.transform.rotation, rotataionGoal, rotateSpeed * Time.deltaTime);
    }

}
