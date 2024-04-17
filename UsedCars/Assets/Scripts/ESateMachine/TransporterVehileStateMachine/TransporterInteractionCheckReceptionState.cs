using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterInteractionCheckReceptionState : CarBaseInteractionState {
    public TransporterInteractionCheckReceptionState(TransportCarContextState transportCarContextState, TransportIntercationStateMachine.ETransportInteractionState statekey) : base(transportCarContextState, statekey) {
        TransportCarContextState transportCarContext = transportCarContextState;

    }
    private PeopleStateMachine peopleStateMachine;
    private Transform currentClient;
    public override void EnterState() {
        currentClient = Context.FirstReceptionChooseCar.GetClientTransform();
        peopleStateMachine = currentClient.GetComponent<PeopleStateMachine>();
        Context.Transporter.CreateCarObject();
    }

    public override void ExitState() {
    }

    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState() {
        if (peopleStateMachine.CheckStateSignContractState()) {
            Context.FirstReceptionChooseCar.FirstRepiarShop.GetCar(Context.Transporter.transform);
            return TransportIntercationStateMachine.ETransportInteractionState.BringCar;
        }
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
