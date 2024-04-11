using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PeopleBaseInteractionState : BaseState<PeopleStateMachine.EPoepleInteractionState> {
    public PeopleContextState PeopleContext;
    public PeopleBaseInteractionState(PeopleContextState peopleContext, PeopleStateMachine.EPoepleInteractionState stateKey) : base(stateKey) {
        PeopleContext = peopleContext;
    }

}
