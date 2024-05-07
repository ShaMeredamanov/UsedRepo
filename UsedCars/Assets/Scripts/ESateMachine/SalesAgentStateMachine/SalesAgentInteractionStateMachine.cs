using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesAgentInteractionStateMachine : StateManager<SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine> {

    public enum ESalesAgentInteractionStateMachine {
        Vacand,
        TalkWithClent,
    }

    private SalesAgentContextState contextStateSalesAgent;


    [SerializeField] private SalesAgentWayPointParent _wayPointParentSalesAgent;
    [SerializeField] private CarsParentPoint _carsParentPoint;
    [SerializeField] private Animator _salesAgentAnimator;
    [SerializeField] private ReceptionChooseCarStateMachine _receptionChooseCarStateMachine;
    [SerializeField] private SalesAgentCellCar _salesAgentCellCar;
    private float timer;
    private float upgarde;
    private void Awake() {
        timer = 3f;
        upgarde = timer / 100; 
        contextStateSalesAgent = new SalesAgentContextState(_wayPointParentSalesAgent, _carsParentPoint,
            this, _salesAgentAnimator, _receptionChooseCarStateMachine, _salesAgentCellCar);
        InitilizeStates();
    }
    private void InitilizeStates() {

        States.Add(ESalesAgentInteractionStateMachine.Vacand, new SalesAgentInteractionVacand(contextStateSalesAgent, ESalesAgentInteractionStateMachine.Vacand));
        States.Add(ESalesAgentInteractionStateMachine.TalkWithClent, new SalesAgentInteractionTalkWithClent(contextStateSalesAgent, ESalesAgentInteractionStateMachine.TalkWithClent));
        CurrentState = States[ESalesAgentInteractionStateMachine.Vacand];
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)) {
            CurrentState.OnTriggerEnter(other);
        }
    }
    private void OnTriggerEnter(Collider other) {
        CurrentState.OnTriggerEnter(other);
    }
    public void ChangeTimerAndUpgrade(float timer) {
        this.timer -= timer;
        upgarde = timer / 100;
    }
    public float Timer => timer;
    public float Upgrade => upgarde;    
}

