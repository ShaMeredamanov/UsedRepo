using UnityEngine;

public class PeopleInteractionInsideInRoomState : PeopleBaseInteractionState {


    private const string IS_WALKING = "IsWalking";
    public PeopleInteractionInsideInRoomState(PeopleContextState contextState, PeopleStateMachine.EPoepleInteractionState statekey) : base(contextState, statekey) {
        PeopleContextState peopleContextState = contextState;
    }

    public override void EnterState() {
        PeopleContext.Animator.SetBool(IS_WALKING, false);
        Debug.Log("Inside in room");
    //    PeopleContext.ReceptionChooseCarStateMachine.GetCleint();
    }

    public override void ExitState() {
      
    }

    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {
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
