using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRepairShopInteractionWithWorker : FirstRepairShopBaseInteraction {


    public FirstRepairShopInteractionWithWorker(FirstRepairShopContext firstRepairShop, FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions statekey) : base(firstRepairShop, statekey) {
        FirstRepairShopContext firstRepairShopContext = firstRepairShop;
    }

    public override void EnterState() {
    }

    public override void ExitState() {
    }

    public override FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions GetNextState() {
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

