using System.Collections;
using UnityEngine;

public class ReceptionChooseCarInteractionFillState : ReceptionChooseCarBaseSate {
    public ReceptionChooseCarInteractionFillState(ReceptionChooseCarContextState firstReceptionChooseCarContextState,
        ReceptionChooseCarStateMachine.EFirstReceptionStateMachine statekey) : base(firstReceptionChooseCarContextState, statekey) {
        ReceptionChooseCarContextState firstReceptionChooseCarContextState1 = firstReceptionChooseCarContextState;
    }
    private float timer;
    private float timerMax;
    private float fillAmount;
    private Coroutine routine;
    private Coroutine secondReotineWaitForCars;
    private const string IS_WORK = "IsWork";
    private float upgradePrice;
    private bool noPlayer;
    public override void EnterState() {
        upgradePrice = ReceptionCarContext.ReceptionChooseCarStateMachine.UpgradePrice;
        timer = ReceptionCarContext.ReceptionChooseCarStateMachine.Timer;
        fillAmount = 0f;
        ReceptionCarContext.Image.fillAmount = 0;
        StartCoroutine();
        ReceptionCarContext.Animator.SetBool(IS_WORK, true);
        noPlayer = false;
    }
    public override void ExitState() {


        ReceptionCarContext.Image.fillAmount = 1;
        StopCoroutine();
        timer = ReceptionCarContext.ReceptionChooseCarStateMachine.Timer;
        ReceptionCarContext.Animator.SetBool(IS_WORK, false);

    }
    public override ReceptionChooseCarStateMachine.EFirstReceptionStateMachine GetNextState() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            upgradePrice = ReceptionCarContext.ReceptionChooseCarStateMachine.UpgradePrice;
            timer = ReceptionCarContext.ReceptionChooseCarStateMachine.Timer;
            timerMax = ReceptionCarContext.ReceptionChooseCarStateMachine.Timer;
            ReceptionCarContext.ReceptionClientsList[0].ChangeStateSignContractState();
            ReceptionCarContext.ReceptionChooseCarStateMachine.TransportIntercationStateMachine().ChanngeStateBringCarState();
            return ReceptionChooseCarStateMachine.EFirstReceptionStateMachine.WithWorker;
        }
        if (noPlayer) {
            noPlayer = false;
            Debug.Log("withoutworker");
            return ReceptionChooseCarStateMachine.EFirstReceptionStateMachine.WithoutWorker;
        }
        return StateKey;
    }
    public override void OnTriggerEnter(Collider other) {
    }
    public override void OnTriggerExit(Collider other) {
        if (!noPlayer) {
            noPlayer = true;
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

    private void SecondStartRoutine() {
        secondReotineWaitForCars = Coroutines.StartRoutine(WaitCars());
    }
    private void SecondStopRoutine() {
        Coroutines.StopRoutine(secondReotineWaitForCars);
    }
    private IEnumerator CalculateTime() {
        while (true) {
            if (fillAmount < 1f) {
                fillAmount += (float)0.0133;
                ReceptionCarContext.Image.fillAmount = (float)fillAmount;
                yield return new WaitForSeconds(upgradePrice);

            } else {
                yield return null;
            }
        }
    }
    private IEnumerator WaitCars() {
        yield return new WaitForSecondsRealtime(0.1f);
        SecondStopRoutine();
    }
}