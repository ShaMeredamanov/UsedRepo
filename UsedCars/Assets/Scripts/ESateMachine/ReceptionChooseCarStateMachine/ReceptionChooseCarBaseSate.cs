using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class ReceptionChooseCarBaseSate : BaseState<ReceptionChooseCarStateMachine.EFirstReceptionStateMachine> {
    protected ReceptionChooseCarContextState ReceptionCarContext;

    public ReceptionChooseCarBaseSate(ReceptionChooseCarContextState Context, ReceptionChooseCarStateMachine.EFirstReceptionStateMachine statekey): base(statekey) {
        ReceptionCarContext = Context;
    }
}
