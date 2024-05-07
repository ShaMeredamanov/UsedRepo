using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SignContractInteractionWithWorkerState : SignContractBaseState {
    public SignContractInteractionWithWorkerState(SignContractContextState signContractContextState, SignContractInteractionStateMachine.ESignContractInteraction statekey) : base(signContractContextState, statekey) {
        SignContractContextState contractContextState = signContractContextState;
    }
    float timer = 1f;
    float timerMax = 1f;
    int score;
    public override void EnterState() {
       
    }

    public override void ExitState() {
    }

    public override SignContractInteractionStateMachine.ESignContractInteraction GetNextState() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = timerMax;
            return SignContractInteractionStateMachine.ESignContractInteraction.WithoutWorker;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerExit(Collider other) {
    }

    public override void OnTriggerStay(Collider other) {
    }

    public override void UpdateState() {
    }
}