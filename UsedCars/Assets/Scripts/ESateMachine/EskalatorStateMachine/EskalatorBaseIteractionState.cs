using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EskalatorBaseIteractionState : BaseState<EskalatorInteractionStateMachine.EEskalatorInteractionState> {
    public EskalatorContextState EskalatorContext;

    public EskalatorBaseIteractionState(EskalatorContextState eskalatorContext, EskalatorInteractionStateMachine.EEskalatorInteractionState stateKey) : base(stateKey) {
        EskalatorContext = eskalatorContext;
    }


}
