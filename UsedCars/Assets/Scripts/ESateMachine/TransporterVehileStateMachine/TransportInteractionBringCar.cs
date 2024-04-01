using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportInteractionBringCar : CarBaseInteractionState
{
    private Transform currentWayPoint;
    private float speed = 20f;
    private float distanceThreeShold = 0.5f;
    private Quaternion rotataionGoal;
    private Vector3 directionToWoyPoint;
    private float rotateSpeed = 5f;
    private Transform parentTransfrom;
    private int childCount;
    public TransportInteractionBringCar(TransportCarContextState transportCarContext, TransportIntercationStateMachine.ETransportInteractionState estate) : base(transportCarContext, estate)
    {
        TransportCarContextState transportCarContextState = transportCarContext;
    }
    public override void EnterState()
    {
        currentWayPoint = Context.Waypoints.GetNextWayPoint(currentWayPoint);
        parentTransfrom = Context.Waypoints.GetThisComponentTransfrom(parentTransfrom);
        childCount = parentTransfrom.childCount;
        Debug.Log(childCount, parentTransfrom);
        Debug.Log("current way point", currentWayPoint);
    }
    public override void ExitState()
    {
        Debug.Log("this is exit state");
    }

    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState()
    {
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex())
        {
            return TransportIntercationStateMachine.ETransportInteractionState.GivesAway;
        }
        else
        {
            return StateKey;
        }
    }
    public override void UpdateState()
    {
        var direction = (currentWayPoint.transform.position - Context.BigCar.transform.position).normalized;
        Context.BigCar.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(Context.BigCar.transform.position, currentWayPoint.position) < distanceThreeShold)
        {
            currentWayPoint = Context.Waypoints.GetNextWayPoint(currentWayPoint);

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