using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesAgentContextState {
    private SalesAgentWayPointParent _salesAgentWayPoint;
    private CarsParentPoint _carsParentPoint;
    private SalesAgentInteractionStateMachine _salesAgentStateMachine;
    private Animator _salesAgentAnimator;
    private ReceptionChooseCarStateMachine _receptionChooseCarStateMachine;
    private SalesAgentCellCar _salesAgentCellCar;
    public SalesAgentContextState(SalesAgentWayPointParent salesAgentWayPointParent,
        CarsParentPoint carsParentPoint, SalesAgentInteractionStateMachine salesAgentStateMachine, Animator salesAgentAnimator, 
        ReceptionChooseCarStateMachine receptionChooseCarStateMachine, SalesAgentCellCar salesAgentCellCar) {
        _salesAgentWayPoint = salesAgentWayPointParent;
        _carsParentPoint = carsParentPoint;
        _salesAgentStateMachine = salesAgentStateMachine;
        _salesAgentAnimator = salesAgentAnimator;
        _receptionChooseCarStateMachine = receptionChooseCarStateMachine;
        _salesAgentCellCar = salesAgentCellCar;

    }
    public SalesAgentWayPointParent SalesAgentWayPointParent => _salesAgentWayPoint;
    public CarsParentPoint CarsParentPoint => _carsParentPoint;
    public SalesAgentInteractionStateMachine SalesAgentStateMachine => _salesAgentStateMachine;
    public Animator SalesAgentAnimator => _salesAgentAnimator;
    public ReceptionChooseCarStateMachine ReceptionChooseCarStateMachine => _receptionChooseCarStateMachine;
    public SalesAgentCellCar SalesAgentCellCars => _salesAgentCellCar;         
}