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
    private ReparingWaypoint.ReapirCarWayPoints _secondRepairShopWayPoint;
    private ReparingWaypoint.ReapirCarWayPoints reparingCarWayPointsThirdCellCar;
    private FirstRepiarShop _firstRepairShop;
    private SecondRepairShop _secondRepairShop;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="firstWayPoints"></param>
    /// <param name="stateMachine"></param>
    public EskalatorContextState(EskalatorWayPoint.EskalatorFirstWayPoints firstWayPoints, TransporterInGarage inGarage, ReparingWaypoint.ReapirCarWayPoints reapirCarWayPoints, ParentConveinerWayPoint.ParentConveinerWayPoint parentConveinerWayPoint,float generalSpeed, EskalatorInteractionStateMachine stateMachine, ReparingWaypoint.ReapirCarWayPoints secondRepairShopWayPoint, ReparingWaypoint.ReapirCarWayPoints reparingCarWayPointsThirdCellCar, FirstRepiarShop firstRepairChooseCar, SecondRepairShop secondRepairChooseCar) {
        _parentConveinerWayPoint = parentConveinerWayPoint;
        _reapirCarWayPoints = reapirCarWayPoints;
        _stateMachine = stateMachine;
        _firstWayPoints = firstWayPoints;
        _inGarage = inGarage;
        _generalSpeed = generalSpeed;
        _secondRepairShopWayPoint = secondRepairShopWayPoint;
        this.reparingCarWayPointsThirdCellCar = reparingCarWayPointsThirdCellCar;
        _firstRepairShop = firstRepairChooseCar;
        _secondRepairShop = secondRepairChooseCar;
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
    public ReparingWaypoint.ReapirCarWayPoints  SecondRepairShopWayPoint => _secondRepairShopWayPoint;

    public ReparingWaypoint.ReapirCarWayPoints ReparingCarWayPointsThirdCellCar => reparingCarWayPointsThirdCellCar;
    public FirstRepiarShop FirstRepairSHop => _firstRepairShop;
    public SecondRepairShop SecondRepairShop => _secondRepairShop;
}