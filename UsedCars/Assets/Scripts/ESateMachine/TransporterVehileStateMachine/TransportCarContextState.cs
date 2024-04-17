using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportCarContextState
{
    private TransporterWayPoint.TransportCarWaypoints _wayPointFirstMoving;
    private GivingACar.TransporterGivesAwayWayPoints _givesAwayWayPoints;
    private TransportIntercationStateMachine _bigCar;
    private CarObject _carObject;
    private TransporterInGarage _inGarage;
    private TransporterCarTurnBackWayPoints _turnBack;
    private Transporter _transporter;
    private FirstReceptionChooseCar _firstReceptionChooseCar;
    private SecondReceptionSignContract _secondReceptionSignContract; 
    private float _generalSpeed;
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="waypoint"></param>
    public TransportCarContextState(TransporterWayPoint.TransportCarWaypoints waypoint, GivingACar.TransporterGivesAwayWayPoints bringCarWayPoints, CarObject carObject, TransporterInGarage inGarage, TransporterCarTurnBackWayPoints turnBack,Transporter transporter ,float generalSpeed,FirstReceptionChooseCar firstReceptionChooseCar, SecondReceptionSignContract secondReceptionSignContract ,TransportIntercationStateMachine bigCar)
    {
        _generalSpeed = generalSpeed;
        _transporter = transporter;
        _givesAwayWayPoints = bringCarWayPoints;
        _bigCar = bigCar;
        _wayPointFirstMoving = waypoint;
        _carObject = carObject;
        _inGarage = inGarage;
        _turnBack = turnBack;
        _firstReceptionChooseCar = firstReceptionChooseCar;
        _secondReceptionSignContract = secondReceptionSignContract;
    }
    /// <summary>
    /// Read only properties
    /// </summary>
    public TransporterWayPoint.TransportCarWaypoints Waypoints => _wayPointFirstMoving;
    /// <summary>
    /// Read only properties
    /// </summary>
    public TransportIntercationStateMachine BigCar => _bigCar;
    /// <summary>
    /// Read only properties
    /// </summary>
    public GivingACar.TransporterGivesAwayWayPoints GivesAwayWayPoints => _givesAwayWayPoints;
    /// <summary>
    /// Read Only properties
    /// </summary>
    public CarObject CarObject => _carObject;
    /// <summary>
    /// Read only properties
    /// </summary>
    public TransporterInGarage InGarage => _inGarage;
    /// <summary>
    /// Read Only properties
    /// </summary>
    public TransporterCarTurnBackWayPoints TurnBack => _turnBack;
    /// <summary>
    /// Read only properties
    /// </summary>
    public Transporter Transporter => _transporter;
    /// <summary>
    /// Read only properties
    /// </summary>
    public float GeneralSpeed => _generalSpeed; 
    /// <summary>
    /// Read only properties
    /// </summary>
    public FirstReceptionChooseCar FirstReceptionChooseCar => _firstReceptionChooseCar;
    /// <summary>
    /// Reaad only properties
    /// </summary>
    public SecondReceptionSignContract SecondReceptionSignContract => _secondReceptionSignContract;
}
