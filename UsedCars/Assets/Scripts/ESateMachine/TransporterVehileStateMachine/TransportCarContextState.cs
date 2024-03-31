using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportCarContextState
{
    private TransporterWayPoint.TransportCarWaypoints _wayPoint;
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="waypoint"></param>
    public TransportCarContextState(TransporterWayPoint.TransportCarWaypoints waypoint)
    {
     _wayPoint = waypoint;
    }
    /// <summary>
    /// Read only properties
    /// </summary>
    public TransporterWayPoint.TransportCarWaypoints Waypoints => _wayPoint;
}
