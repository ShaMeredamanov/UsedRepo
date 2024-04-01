using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarBaseInteractionState : BaseState<TransportIntercationStateMachine.ETransportInteractionState>
{
    public TransportCarContextState Context;
    public CarBaseInteractionState(TransportCarContextState context, TransportIntercationStateMachine.ETransportInteractionState stateKey) : base(stateKey)
    {
        Context = context;
    }
}
