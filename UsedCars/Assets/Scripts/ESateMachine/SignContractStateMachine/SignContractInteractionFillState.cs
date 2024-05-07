using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignContractInteractionFillState : SignContractBaseState {
    public SignContractInteractionFillState(SignContractContextState signContractContextState, SignContractInteractionStateMachine.ESignContractInteraction statekey) : base(signContractContextState, statekey) {
        SignContractContextState signContractContext = signContractContextState;
    }
    private float timer;
    private float fillAmount;
    private Coroutine routine;
    private const string IS_WORK = "IsWork";
    private int moneyIndex;
    private bool noPLayer;
    public override void EnterState() {
        timer = SignContextState.SignContractInteractionStateMachine.Timer;
        noPLayer = false;
        fillAmount = 0.0f;
        SignContextState.Image.fillAmount = 0f;
        StartCoroutine();
        SignContextState.WorkerAnimator.SetBool(IS_WORK, true);
    }

    public override void ExitState() {
        SignContextState.WorkerAnimator.SetBool(IS_WORK, false);
        StopRoutine();
        SignContextState.Image.fillAmount = 1f;
        //  upgradeFillAmount = 0.055f; 
        //    SignContextState.MoneyInScene.fillAmount += upgradeFillAmount;
        for (int i = 0; i < 12; i++) {
            if (moneyIndex < SignContextState.MoneyObjectList.Count - 1) {
                SignContextState.MoneyObjectList[moneyIndex].SetActive(true);
                moneyIndex++;
            } else {
                moneyIndex = 0;
            }
        }
    }

    public override SignContractInteractionStateMachine.ESignContractInteraction GetNextState() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = SignContextState.SignContractInteractionStateMachine.Timer;

            SignContextState.Canvas.GEtMoney(SignContextState.PeopleStateMachinesList[0].GetCurrentMoneys());
            SignContextState.PeopleStateMachinesList[0].ChangeStateToBuyCar();
            SignContextState.SignContractInteractionStateMachine.RemoveClearFromEskaltorInteractionStateMachineList();
            SignContextState.SignContractInteractionStateMachine.ClearAndRemoveClient();
            StopRoutine();
            foreach (PeopleStateMachine peopleStateMachines in SignContextState.PeopleStateMachinesList) {
                peopleStateMachines.ChangeToGetStateAgaingToTrue();
            }
            return SignContractInteractionStateMachine.ESignContractInteraction.WithWorker;
        }
        if (noPLayer) {
            noPLayer = false;
            return SignContractInteractionStateMachine.ESignContractInteraction.WithoutWorker;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerExit(Collider other) {
        if (!noPLayer) {
            noPLayer = true;
        }
    }

    public override void OnTriggerStay(Collider other) {
    }

    public override void UpdateState() {
    }
    private void StartCoroutine() {
        routine = Coroutines.StartRoutine(CalculateTime());
    }

    private void StopRoutine() {
        Coroutines.StopRoutine(routine);
    }
    private IEnumerator CalculateTime() {
        while (true) {
            if (fillAmount < 1f) {
                fillAmount += (float)0.0125f;
                SignContextState.Image.fillAmount = (float)fillAmount;
                yield return new WaitForSeconds(SignContextState.SignContractInteractionStateMachine.Upgrade);
            } else {
                yield return null;
            }
        }
    }
}