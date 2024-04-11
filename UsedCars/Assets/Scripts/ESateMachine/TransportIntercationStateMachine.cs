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
        TurnBack,
    }
    [SerializeField] private TransporterWayPoint.TransportCarWaypoints wayPoint;
    [SerializeField] private GivingACar.TransporterGivesAwayWayPoints givesAwayWayPoints;
    [SerializeField] private CarObject carObject;
    [SerializeField] private TransporterInGarage transporterInGarage;
    [SerializeField] private TransporterCarTurnBackWayPoints _turnBack;
    [SerializeField] private Transform convierSPawnPoint;
    private Transporter _transporter;
    private float _generalSpeed = 80f;



    private TransportCarContextState _context;

    private void Awake()
    {
        _transporter = GetComponent<Transporter>();
        _context = new TransportCarContextState(wayPoint, givesAwayWayPoints, carObject, transporterInGarage, _turnBack, _transporter, _generalSpeed,this);

        InitializeStates();
    }

    private void InitializeStates()
    {
        States.Add(ETransportInteractionState.BringCar, new TransportInteractionBringCar(_context, ETransportInteractionState.BringCar));
        States.Add(ETransportInteractionState.GivesAway, new TransportIntercationsGivesCarAway(_context, ETransportInteractionState.GivesAway));
        States.Add(ETransportInteractionState.WaitState, new TransportInteractionWaitState(_context, ETransportInteractionState.WaitState));
        States.Add(ETransportInteractionState.TurnBack, new TransportInteractionTurnBackState(_context, ETransportInteractionState.TurnBack));
        CurrentState = States[ETransportInteractionState.BringCar];

    }

    public ITransportParent GetConveir()
    {
        var conveir = Instantiate(transporterInGarage.gameObject, convierSPawnPoint.position, convierSPawnPoint.rotation);
        var iTransporterParent = conveir.GetComponent<ITransportParent>();
        return iTransporterParent;
    }
}