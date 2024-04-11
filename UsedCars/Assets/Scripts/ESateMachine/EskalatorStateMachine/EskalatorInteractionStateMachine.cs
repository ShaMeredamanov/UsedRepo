    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionStateMachine : StateManager<EskalatorInteractionStateMachine.EEskalatorInteractionState>
{
    public enum EEskalatorInteractionState
    {
        WaitCarState,
        MoveGarage,
        RepairState,
        SellCar,
    }
    [SerializeField] private EskalatorWayPoint.EskalatorFirstWayPoints eskalatorWayPoint;
    [SerializeField] private ReparingWaypoint.ReapirCarWayPoints _reapirCarWayPoints;
    [SerializeField] private ParentConveinerWayPoint.ParentConveinerWayPoint parentConveiner;
    private EskalatorContextState _eskalatorContext;
    private TransporterInGarage _inGarage;
    private float generalSpeed = 80f;

    private void Awake()
    {
        _inGarage = GetComponent<TransporterInGarage>();
        _eskalatorContext = new EskalatorContextState(eskalatorWayPoint, _inGarage, _reapirCarWayPoints, parentConveiner, generalSpeed,this);
        InitilizeStates();
    }
    private void InitilizeStates()
    {
        States.Add(EEskalatorInteractionState.WaitCarState, new EskaltorInteractionWaitCarState(_eskalatorContext, EEskalatorInteractionState.WaitCarState));
        States.Add(EEskalatorInteractionState.MoveGarage, new EskalatorInteractionMoveGarage(_eskalatorContext, EEskalatorInteractionState.MoveGarage));
        States.Add(EEskalatorInteractionState.RepairState, new EskalatorInteractionRapairCar(_eskalatorContext, EEskalatorInteractionState.RepairState));
        States.Add(EEskalatorInteractionState.SellCar, new EskalatorInteractionSellCar(_eskalatorContext, EEskalatorInteractionState.SellCar));
        CurrentState = States[EEskalatorInteractionState.WaitCarState];
    }
}
