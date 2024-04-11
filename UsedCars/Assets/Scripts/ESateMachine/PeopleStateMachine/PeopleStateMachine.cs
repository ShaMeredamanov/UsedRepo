using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleStateMachine : StateManager<PeopleStateMachine.EPoepleInteractionState> {
    public enum EPoepleInteractionState {
        WalkAroundState,
        InsideInRoomState,
        BuyCarState,
        WalkCarSideState,
        SignContractState,




    }
    private void Awake() {

    }
    private void OnServerInitialized() {
    }
}

