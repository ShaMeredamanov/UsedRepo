using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInteractionInsideInRoomState : PeopleBaseInteractionState {


    private float timer = 5f;
    private float timerMax = 5f;
    private const string IS_WALKING = "IsWalking";
    private Transform transform;
    private WaitingQueueParent waitingQueueParent;
    private Transform currentWaypoint;
    public PeopleInteractionInsideInRoomState(PeopleContextState contextState, PeopleStateMachine.EPoepleInteractionState statekey) : base(contextState, statekey) {
        PeopleContextState peopleContextState = contextState;
    }

    public override void EnterState() {
        PeopleContext.Animator.SetBool(IS_WALKING, false);
        waitingQueueParent = PeopleContext.WaitingQueueParent;
    }

    public override void ExitState() {
    }

    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {
        if (PeopleContext.FirstReceptionChooseCar.HasPlayer()) {
            if (waitingQueueParent.ChildrensTransforms.Count - 1 > waitingQueueParent.Index) {
                timer -= Time.deltaTime;
                if (timer < 0) {
                    PeopleContext.SecondReceptionSignContract.GetClient(PeopleContext.PeopleStateMachine.transform);
                    PeopleContext.FirstReceptionChooseCar.ClearClient();
                    PeopleContext.FirstReceptionChooseCar.GetClient(transform);
                    timer = timerMax;
                    return PeopleStateMachine.EPoepleInteractionState.SignContractState;
                }
            }
        } else if (PeopleContext.FirstReceptionChooseCar.FemaleCashier != null) {
            if (waitingQueueParent.ChildrensTransforms.Count - 1 > waitingQueueParent.Index) {
                timer -= Time.deltaTime;
                if (timer < 0) {
                    PeopleContext.SecondReceptionSignContract.GetClient(PeopleContext.PeopleStateMachine.transform);
                    PeopleContext.FirstReceptionChooseCar.ClearClient();
                    PeopleContext.FirstReceptionChooseCar.GetClient(transform);
                    timer = timerMax;
                    return PeopleStateMachine.EPoepleInteractionState.SignContractState;
                }
            }
        } else {
            timer = timerMax;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void UpdateState() {
    }
}
