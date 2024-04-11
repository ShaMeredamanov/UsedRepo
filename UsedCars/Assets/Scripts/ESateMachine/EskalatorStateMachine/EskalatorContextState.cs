using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorContextState {
    /// <summary>
    /// This just base constructor for get variables
    /// </summary>
    private EskalatorWayPoint.EskalatorFirstWayPoints _firstWayPoints;
    private EskalatorInteractionStateMachine _stateMachine;
    private TransporterInGarage _inGarage;
    private ReparingWaypoint.ReapirCarWayPoints _reapirCarWayPoints;
    private float _generalSpeed;
    private ParentConveinerWayPoint.ParentConveinerWayPoint _parentConveinerWayPoint;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="firstWayPoints"></param>
    /// <param name="stateMachine"></param>
    public EskalatorContextState(EskalatorWayPoint.EskalatorFirstWayPoints firstWayPoints, TransporterInGarage inGarage, ReparingWaypoint.ReapirCarWayPoints reapirCarWayPoints, ParentConveinerWayPoint.ParentConveinerWayPoint parentConveinerWayPoint,float generalSpeed, EskalatorInteractionStateMachine stateMachine) {
        _parentConveinerWayPoint = parentConveinerWayPoint;
        _reapirCarWayPoints = reapirCarWayPoints;
        _stateMachine = stateMachine;
        _firstWayPoints = firstWayPoints;
        _inGarage = inGarage;
        _generalSpeed = generalSpeed;
    }
    /// <summary>
    /// Read only properties
    /// </summary>
    public EskalatorWayPoint.EskalatorFirstWayPoints FirstWayPoints => _firstWayPoints;
    public EskalatorInteractionStateMachine EskalatorStateMachine => _stateMachine;
    public TransporterInGarage InGarage => _inGarage;
    public ReparingWaypoint.ReapirCarWayPoints ReapirCarWayPoints => _reapirCarWayPoints;
    public ParentConveinerWayPoint.ParentConveinerWayPoint ParentConveinerWayPoint => _parentConveinerWayPoint;
    public float GeneralSpeed => _generalSpeed; 
}