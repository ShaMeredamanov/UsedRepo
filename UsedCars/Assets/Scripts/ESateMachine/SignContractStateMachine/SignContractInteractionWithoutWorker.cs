using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignContractInteractionWithoutWorker : SignContractBaseState {
    public SignContractInteractionWithoutWorker(SignContractContextState signContractContextState, SignContractInteractionStateMachine.ESignContractInteraction statekey) : base(signContractContextState, statekey) {
        SignContractContextState signContractContext = signContractContextState;
    }
    private bool canChangeState;
    public override void EnterState() {
        canChangeState = false;
        SignContextState.Image.fillAmount = 0;
    }

    public override void ExitState() {
        canChangeState = false;
    }

    public override SignContractInteractionStateMachine.ESignContractInteraction GetNextState() {
        if (canChangeState) {
            canChangeState = false;
            return SignContractInteractionStateMachine.ESignContractInteraction.FillState;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {

    }

    public override void OnTriggerExit(Collider other) {

    }

    public override void OnTriggerStay(Collider other) {
        if (SignContextState.PeopleStateMachinesList.Count  > 0) {
            if (SignContextState.EskalatorInteractionStateMachinesList.Count > 0) {
                canChangeState = true;
            }
        }
    }

    public override void UpdateState() {
    }
}