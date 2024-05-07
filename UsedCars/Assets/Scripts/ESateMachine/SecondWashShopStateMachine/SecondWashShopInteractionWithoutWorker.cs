
using UnityEngine;

public class SecondWashShopInteractionWithoutWorker : SecondWashShopBaseState {

    public SecondWashShopInteractionWithoutWorker(SecondWashShopContextState secondWashShopContext, SecondWashShopStateMachine.ESecondWashShopInteraction statekey) : base(secondWashShopContext, statekey) {
        SecondWashShopContextState secondWashShopContextState = secondWashShopContext;
    }
    private const string WASH = "Wash";
    public override void EnterState() {
        WashContext.Animator.SetBool(WASH, false);
        WashContext.ParticleSystem.Stop();
        WashContext.ParticleSystemSecond.Stop();
        WashContext.BubbleShower.Stop();
    }

    public override void ExitState() {
    }

    public override SecondWashShopStateMachine.ESecondWashShopInteraction GetNextState() {
        if (WashContext.EskalatorInteractionStateMachines.Count > 0) {
            WashContext.OutLine.gameObject.SetActive(true);
        } else {
            WashContext.OutLine.gameObject.SetActive(false);
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerExit(Collider other) {


    }

    public override void OnTriggerStay(Collider other) {
        if (WashContext.SignContractInteractionStateMachines.EskalatorInteractionStateMachinesList.Count < 1) {
            WashContext.SecondWashShopStateMachine.ChangeStates();
        }
    }


    public override void UpdateState() {

    }
}
