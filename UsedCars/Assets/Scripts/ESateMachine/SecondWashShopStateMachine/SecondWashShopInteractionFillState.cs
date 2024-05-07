using System.Collections;
using UnityEngine;

public class SecondWashShopInteractionFillState : SecondWashShopBaseState {
    public SecondWashShopInteractionFillState(SecondWashShopContextState secondWashShopContextState, SecondWashShopStateMachine.ESecondWashShopInteraction statekey) : base(secondWashShopContextState, statekey)
    {
            SecondWashShopContextState secondWashShopContextState1 = secondWashShopContextState;
    }
    private float timer;
    private Coroutine routine;
    private float fillAmount;
    private bool exitState;
    private int moneyIndex;
    private const string WASH = "Wash";
    private const string IS_WORK = "IsWork";
    public override void EnterState() {
        fillAmount = 0f;
        WashContext.Image.fillAmount = 0;
        StartCoroutine();
        WashContext.ParticleSystem.Play();
        WashContext.ParticleSystemSecond.Play();
        WashContext.BubbleShower.Play();
        WashContext.Animator.SetBool(WASH, true);
        WashContext.WorkerAnimator.SetBool(IS_WORK, true);
        timer = WashContext.SecondWashShopStateMachine.Timer;
    }
    public override void ExitState() {
        exitState = false;
        StopCoroutine();
        WashContext.ParticleSystem.Stop();
        WashContext.Animator.SetBool(WASH, false);
        WashContext.WorkerAnimator.SetBool(IS_WORK, false);
        WashContext.Image.fillAmount = 0f;
    }
    public override SecondWashShopStateMachine.ESecondWashShopInteraction GetNextState() {
        timer -= Time.deltaTime;
        if(timer < 0) {

            timer = WashContext.SecondWashShopStateMachine.Timer;
            WashContext.SignContractInteractionStateMachines.GetEsklatorInteractionStateMachineToList(WashContext.SecondWashShopStateMachine.EskalatorInteractionStateMachinesList[0]);
            WashContext.SecondWashShopStateMachine.EskalatorInteractionStateMachinesList[0].ChangeStateToSellCarState();
            return SecondWashShopStateMachine.ESecondWashShopInteraction.WaitExitCar;
        }
        if (exitState) {

            timer = WashContext.SecondWashShopStateMachine.Timer;
            exitState = false;
            fillAmount = 0f;
            WashContext.Image.fillAmount = 0;
            return SecondWashShopStateMachine.ESecondWashShopInteraction.WithoutWorker;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
    }
    public override void OnTriggerExit(Collider other) {
        if(other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            exitState = true;
        }

    }
    public override void OnTriggerStay(Collider other) {
    }
    public override void UpdateState() {
    }
    private void StartCoroutine() {
        routine = Coroutines.StartRoutine(CalculateTime());
    }
    private void StopCoroutine() {

        Coroutines.StopRoutine(routine);
    }

    private IEnumerator CalculateTime() {
        while (true) {
            if (fillAmount < 1f) {
                fillAmount += (float)0.0133f;
                WashContext.Image.fillAmount = (float)fillAmount;
                yield return new WaitForSeconds(WashContext.SecondWashShopStateMachine.Upgrade);
            } else {
                yield return null;
            }
        }
    }
}