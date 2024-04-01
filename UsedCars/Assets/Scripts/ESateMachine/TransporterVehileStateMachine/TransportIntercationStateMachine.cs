using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportIntercationStateMachine : StateManager<TransportIntercationStateMachine.ETransportInteractionState>
{
    public enum ETransportInteractionState
    {
        GivesAway,
        BringCar,
        WaitState,
    }
    [SerializeField] private TransporterWayPoint.TransportCarWaypoints wayPoint;
    [SerializeField] private GivingACar.TransporterGivesAwayWayPoints givesAwayWayPoints;
    [SerializeField] private CarObject carObject;

    public TransporterWayPoint.TransportCarWaypoints Waypoint => wayPoint;

    private TransportCarContextState _context;

    private void Awake()
    {
        _context = new TransportCarContextState(wayPoint, givesAwayWayPoints, carObject, this);

        InitializeStates();
    }

    private void InitializeStates()
    {
        States.Add(ETransportInteractionState.BringCar, new TransportInteractionBringCar(_context, ETransportInteractionState.BringCar));
        States.Add(ETransportInteractionState.GivesAway, new TransportIntercationsGivesCarAway(_context, ETransportInteractionState.GivesAway));
        States.Add(ETransportInteractionState.WaitState, new TransportInteractionWaitState(_context, ETransportInteractionState.WaitState));
        CurrentState = States[ETransportInteractionState.BringCar];

    }
}