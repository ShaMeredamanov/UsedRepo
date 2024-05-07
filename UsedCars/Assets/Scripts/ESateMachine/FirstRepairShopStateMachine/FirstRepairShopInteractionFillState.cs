using System.Collections;
using UnityEngine;

public class FirstRepairShopInteractionFillState : FirstRepairShopBaseInteraction {
    public FirstRepairShopInteractionFillState(FirstRepairShopContext firstRepairShopContext, FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions statekey) : base(firstRepairShopContext, statekey) {
        FirstRepairShopContext firstRepairShop = firstRepairShopContext;
    }
    float timer;
    private float fillAmount;
    private Coroutine routine;
    private bool exitState;
    private Coroutine waitForCars;
    private const string REPAIR = "Repair";
    private const string IS_WORK = "IsWork";
    public override void EnterState() {
        exitState = false;
        fillAmount = 0;
        context.Image.fillAmount = 0;
        StartTestRoutine();
        timer = context.FirstRepairShopInteractionStateMachine.Timer;


    }
    public override void ExitState() {
        StopTestRputine();
        context.ParticleSystem.Stop();
        context.Animator.SetBool(REPAIR, false);
        context.WorkerAnimator.SetBool(IS_WORK, false);
        exitState = false;

        context.Image.fillAmount = 0;
    }
    public override FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions GetNextState() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = context.FirstRepairShopInteractionStateMachine.Timer;
            StopTestRputine();

            context.Animator.SetBool(IS_WORK, false);
            context.SecondWashShopStateMachine.GetEskalatorToList(context.EskalatorInteractionStateMachinesList[0]);
            context.EskalatorInteractionStateMachinesList[0].GetComponent<EskalatorInteractionStateMachine>().ChangeState();
            context.FirstRepairShopInteractionStateMachine.RemoveFromEsklatorList(context.EskalatorInteractionStateMachinesList[0]);
            return FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions.WIthoutWorker;
        }
        if (exitState) {
            //    fillAmount = 0;
            //    context.Image.fillAmount = 0;
            exitState = false;
            timer = context.FirstRepairShopInteractionStateMachine.Timer;
            return FirstRepairShopInteractionStateMachine.EFirstRepairShopIntersctions.WIthoutWorker;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            exitState = true;

        }
    }

    public override void OnTriggerStay(Collider other) {
    }

    public override void UpdateState() {
    }
    public IEnumerator CalculateTime() {
        while (true) {
            if (fillAmount < 1f) {
                fillAmount += (float)0.0133f;
                context.Image.fillAmount = (float)fillAmount;
                yield return new WaitForSeconds(context.FirstRepairShopInteractionStateMachine.UpgardeTimer);
            } else {
                yield return null;
            }
        }
    }
    private IEnumerator WaitCar() {
        yield return new WaitForSecondsRealtime(0.5f);
        context.Animator.SetBool(REPAIR, true);
        context.WorkerAnimator.SetBool(IS_WORK, true);
        context.ParticleSystem.Play();
        this.routine = Coroutines.StartRoutine(this.CalculateTime());

    }
    public void StartTestRoutine() {
        if (this.routine != null)
            return;
        waitForCars = Coroutines.StartRoutine(WaitCar());

    }
    public void StopTestRputine() {
        Coroutines.StopRoutine(this.routine);
        Coroutines.StopRoutine(waitForCars);
        this.routine = null;
    }
}