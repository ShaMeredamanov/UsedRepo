using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SignContractBaseState : BaseState<SignContractInteractionStateMachine.ESignContractInteraction> {


    protected SignContractContextState SignContextState;

    public SignContractBaseState(SignContractContextState signContextState, SignContractInteractionStateMachine.ESignContractInteraction statekey) : base(statekey) {
        SignContextState = signContextState;
    }
}