using UnityEngine;

public class SecondWashShopInteractionWaitCarExit : SecondWashShopBaseState {

    public SecondWashShopInteractionWaitCarExit(SecondWashShopContextState secondWashShopContext, SecondWashShopStateMachine.ESecondWashShopInteraction statekey): base(secondWashShopContext, statekey)
    {
            SecondWashShopContextState secondWashShopContextState = secondWashShopContext;
    }
    private bool canChangeState;
    public override void EnterState() {
        canChangeState = false;
    }

    public override void ExitState() {

    }

    public override SecondWashShopStateMachine.ESecondWashShopInteraction GetNextState() {
        if (canChangeState) {
            canChangeState = false;
            return SecondWashShopStateMachine.ESecondWashShopInteraction.WithoutWorker;
        }
        return StateKey;

    }

    public override void OnTriggerEnter(Collider other) {
 
    }

    public override void OnTriggerExit(Collider other) {
        canChangeState = true;
    }

    public override void OnTriggerStay(Collider other) {
    }

    public override void UpdateState() {
    }
}
