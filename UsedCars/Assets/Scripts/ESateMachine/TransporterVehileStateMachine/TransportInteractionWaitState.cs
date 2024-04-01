using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportInteractionWaitState : CarBaseInteractionState
{
    public TransportInteractionWaitState (TransportCarContextState transportCarContext, TransportIntercationStateMachine.ETransportInteractionState estate) : base(transportCarContext, estate)
    {
        TransportCarContextState transportCarContextState = transportCarContext;

    }
    public override void EnterState()
    {
        Context.CarObject.SetUsedCars(Context.BigCar.transform);
    }

    public override void ExitState()
    {
        Debug.Log("exit state in wait state");
    }

    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState()
    {
        Debug.Log("state changer in wait state");
        return StateKey;
    }

    public override void UpdateState()
    {

        Debug.Log("update state in wait state");
    }

}
