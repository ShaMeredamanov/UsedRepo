using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionBeforeCellCar : EskalatorBaseIteractionState {


    public EskalatorInteractionBeforeCellCar(EskalatorContextState eskalatorContextState, EskalatorInteractionStateMachine.EEskalatorInteractionState stateKey) : base(eskalatorContextState, stateKey) {
        EskalatorContextState contextState = eskalatorContextState;

    }

     public override void EnterState() {
        Debug.Log("enter state");
     }

    public override void ExitState() {
    }

    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState() {
        Debug.Log("getnextState state");
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerExit(Collider other) {
    }

    public override void OnTriggerStay(Collider other) {
    }

    public override void UpdateState() {
        Debug.Log("update state");
    }
}
