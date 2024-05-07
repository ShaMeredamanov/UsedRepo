using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FirstRepairShopInteractionWithOutWorker : FirstRepairShopBaseInteraction {
    public FirstRepairShopInteractionWithOutWorker(FirstRepairShopContext firstRepairShop, FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions statekey) : base(firstRepairShop, statekey) {
        FirstRepairShopContext firstRepairShopContext = firstRepairShop;
    }
    private bool canChagneState;
    public override void EnterState() {
        canChagneState = false;
    }

    public override void ExitState() {
    }

    public override FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions GetNextState() {
        if (canChagneState) {
            canChagneState = false;
            return FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions.FillState;
        }
        if(context.EskalatorInteractionStateMachinesList.Count > 0) {
            context.OutLine.gameObject.SetActive(true);
        } else {
            context.OutLine.gameObject.SetActive(false);
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
        
    }

    public override void OnTriggerExit(Collider other) {
    }

    public override void OnTriggerStay(Collider other) {
        if (context.SecondWashShopStateMachine.EskalatorInteractionStateMachinesList.Count < 1) {
            canChagneState = true;
            //context.SecondRepairShop.GetEskalatorToList(context.FirstRepairShopInteractionStateMachine.EskalatorInteractionStateMachine);

        }
    }
    public override void UpdateState() {

    }
}