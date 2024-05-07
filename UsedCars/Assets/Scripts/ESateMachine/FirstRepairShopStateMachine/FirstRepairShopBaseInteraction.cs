using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FirstRepairShopBaseInteraction : BaseState<FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions> {

    public FirstRepairShopContext context;
    public FirstRepairShopBaseInteraction(FirstRepairShopContext repairShopContext, FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions statekey) : base(statekey) {
        context = repairShopContext;
    }
}