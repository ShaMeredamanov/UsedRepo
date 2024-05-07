using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionChooseCarInteractionWithWorker : ReceptionChooseCarBaseSate {

    public ReceptionChooseCarInteractionWithWorker(ReceptionChooseCarContextState firstReceptionChooseCarContextState, 
        ReceptionChooseCarStateMachine.EFirstReceptionStateMachine statekey): base (firstReceptionChooseCarContextState, statekey)
    {
            ReceptionChooseCarContextState firstReceptionChooseCarContextState1 = firstReceptionChooseCarContextState;
    }
    private float timer =3f; 
    private float timerMax =3f; 
    public override void EnterState() {
        timer = timerMax;
        ReceptionCarContext.ReceptionChooseCarStateMachine.RemoveClient();
        ReceptionCarContext.ReceptionChooseCarStateMachine.GetCleint();
    }

    public override void ExitState() {

    }

    public override ReceptionChooseCarStateMachine.EFirstReceptionStateMachine GetNextState() {
        timer -= Time.deltaTime;
        if(timer < 0) {
            timer = timerMax;
            return ReceptionChooseCarStateMachine.EFirstReceptionStateMachine.WithoutWorker;
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