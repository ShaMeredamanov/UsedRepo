using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SecondWashShopBaseState : BaseState<SecondWashShopStateMachine.ESecondWashShopInteraction> {
    public SecondWashShopContextState WashContext;
    public SecondWashShopBaseState(SecondWashShopContextState secondWashShopContextState, SecondWashShopStateMachine.ESecondWashShopInteraction statekey) : base(statekey)
    {
            WashContext = secondWashShopContextState;
    }
}