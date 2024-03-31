using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportIntercationStateMachine : StateManager<TransportIntercationStateMachine.ETransportInteractionState>
{
    public enum ETransportInteractionState
    {
        GivesAway,
        BringCar,
    }
    [SerializeField] private  TransporterWayPoint.TransportCarWaypoints wayPoint;
    public TransporterWayPoint.TransportCarWaypoints Waypoint => wayPoint;

    private TransportCarContextState _context;
    private void Awake()
    {
        Debug.Log("  InitializeStates();");
         _context = new TransportCarContextState(wayPoint);
        InitializeStates();
    }
   
    private void InitializeStates()
    {
        States.Add(ETransportInteractionState.BringCar, new TransportInteractionBringCar(_context, ETransportInteractionState.BringCar));
        States.Add(ETransportInteractionState.GivesAway, new TransportIntercationsGivesCarAway(_context, ETransportInteractionState.GivesAway));
        CurrentState = States[ETransportInteractionState.BringCar];
    }
}