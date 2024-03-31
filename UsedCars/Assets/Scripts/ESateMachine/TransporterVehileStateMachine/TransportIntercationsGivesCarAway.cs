using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportIntercationsGivesCarAway : CarBaseInteractionState
{
    public TransportIntercationsGivesCarAway(TransportCarContextState transportCarContext, TransportIntercationStateMachine.ETransportInteractionState estate) : base(transportCarContext, estate)
    {
        TransportCarContextState transportCarContextState = transportCarContext;
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}
