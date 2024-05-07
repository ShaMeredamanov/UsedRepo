using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterInteractionCheckReceptionState : CarBaseInteractionState {
    public TransporterInteractionCheckReceptionState(TransportCarContextState transportCarContextState, TransportIntercationStateMachine.ETransportInteractionState statekey) : base(transportCarContextState, statekey) {
        TransportCarContextState transportCarContext = transportCarContextState;

    }
   
    public override void EnterState() {
        Context.Transporter.CreateCarObject();
    }

    public override void ExitState() {
    }

    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState() {
       
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other) {

    }

    public override void OnTriggerStay(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void UpdateState() {
    }
}
