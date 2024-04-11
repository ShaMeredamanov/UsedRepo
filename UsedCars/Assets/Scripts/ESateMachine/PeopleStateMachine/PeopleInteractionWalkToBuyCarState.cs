using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInteractionWalkToBuyCarState : PeopleBaseInteractionState
{
    public PeopleInteractionWalkToBuyCarState(PeopleContextState peopleContextState, PeopleStateMachine.EPoepleInteractionState statekey): base(peopleContextState, statekey)
    {
        PeopleContextState peopleContext = peopleContextState;
    }

    public override void EnterState() {
        throw new System.NotImplementedException();
    }

    public override void ExitState() {
        throw new System.NotImplementedException();
    }

    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void UpdateState() {
        throw new System.NotImplementedException();
    }
}
