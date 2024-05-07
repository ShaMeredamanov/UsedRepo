using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReseptionChooseCarInteractionWithoutWorker : ReceptionChooseCarBaseSate {

    public ReseptionChooseCarInteractionWithoutWorker(ReceptionChooseCarContextState firstReceptionChooseCarContextState, ReceptionChooseCarStateMachine.EFirstReceptionStateMachine statekey) : base(firstReceptionChooseCarContextState, statekey) {
        ReceptionChooseCarContextState firstReceptionChooseCarContextState1 = firstReceptionChooseCarContextState;

    }
    private bool canChangeState;
    public override void EnterState() {
        canChangeState = false;
        ReceptionCarContext.Image.fillAmount = 0;
    }

    public override void ExitState() {

    }

    public override ReceptionChooseCarStateMachine.EFirstReceptionStateMachine GetNextState() {
        if (canChangeState) {
            canChangeState = false;
            return ReceptionChooseCarStateMachine.EFirstReceptionStateMachine.FillState;
        }
        return StateKey;

    }

    public override void OnTriggerEnter(Collider other) {

    }

    public override void OnTriggerExit(Collider other) {
    }

    public override void OnTriggerStay(Collider other) {
        if (ReceptionCarContext.ReceptionClientsList[0].CheckStateIsStateInsideRoom()) {
            if (ReceptionCarContext.WaitingQueueParent.Index < ReceptionCarContext.WaitingQueueParent.ChildrensTransforms.Count - 1) {
                canChangeState = true;
            }
        }
    }

    public override void UpdateState() {

    }
}