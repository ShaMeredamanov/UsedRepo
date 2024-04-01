using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportCarContextState
{
    private TransporterWayPoint.TransportCarWaypoints _wayPointFirstMoving;
    private GivingACar.TransporterGivesAwayWayPoints _givesAwayWayPoints;
    private TransportIntercationStateMachine _bigCar;
    private CarObject _carObject;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="waypoint"></param>
    public TransportCarContextState(TransporterWayPoint.TransportCarWaypoints waypoint, GivingACar.TransporterGivesAwayWayPoints bringCarWayPoints, CarObject carObject, TransportIntercationStateMachine bigCar)
    {

        _givesAwayWayPoints = bringCarWayPoints;
        _bigCar = bigCar;
        _wayPointFirstMoving = waypoint;
        _carObject = carObject;
    }

    /// <summary>
    /// Read only properties
    /// </summary>
    public TransporterWayPoint.TransportCarWaypoints Waypoints => _wayPointFirstMoving;
    public TransportIntercationStateMachine BigCar => _bigCar;
    public GivingACar.TransporterGivesAwayWayPoints GivesAwayWayPoints => _givesAwayWayPoints;
    public CarObject CarObject => _carObject;
}
