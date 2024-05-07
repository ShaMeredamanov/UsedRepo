using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SalesAgentBaseState : BaseState<SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine> {
    public SalesAgentContextState SalesAgentContext;
    public SalesAgentBaseState(SalesAgentContextState salesAgentContext, SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine stateKey) : base(stateKey) {
        SalesAgentContext = salesAgentContext;
    }


}
