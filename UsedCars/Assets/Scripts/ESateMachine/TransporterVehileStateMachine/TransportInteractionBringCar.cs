using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportInteractionBringCar : CarBaseInteractionState
{
    private Transform currentWayPoint;
    
    public TransportInteractionBringCar(TransportCarContextState transportCarContext, TransportIntercationStateMachine.ETransportInteractionState estate) : base(transportCarContext, estate)
    {
        TransportCarContextState transportCarContextState = transportCarContext;
    }

    public override void EnterState()
    {
        Debug.Log("name of context" );

        currentWayPoint = Context.Waypoints.GetNextWayPoint(currentWayPoint);

        Debug.Log("hello from Exit state", currentWayPoint);

    }

    public override void ExitState()
    {
    }

    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState()
    {
        Debug.Log("what is that");

        return StateKey;
    }

    public override void UpdateState()
    {

        Debug.Log("hello from update state");
    }
}