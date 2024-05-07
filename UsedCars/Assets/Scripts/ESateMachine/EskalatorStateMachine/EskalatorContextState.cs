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
    private ReparingWaypoint.ReapirCarWayPoints _secondRepairShopWayPoint;
    private ReparingWaypoint.ReapirCarWayPoints reparingCarWayPointsThirdCellCar;
    private FirstCarRepairWayPointParent _firstCarRepairWayPointParent;
    private ParticleSystem _particleSystem;
    private ThirdWayPointParentForQueue _thirdWayPointParentForQueue;
    private SecondWashShopStateMachine _secondWashShopStateMachine;
    private ParticleSystem _particleSystemSecond;
    private Animator _topPointAnimation;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="firstWayPoints"></param>
    /// <param name="stateMachine"></param>
    public EskalatorContextState(EskalatorWayPoint.EskalatorFirstWayPoints firstWayPoints, TransporterInGarage inGarage, 
        ReparingWaypoint.ReapirCarWayPoints reapirCarWayPoints,
        float generalSpeed, EskalatorInteractionStateMachine stateMachine, 
        ReparingWaypoint.ReapirCarWayPoints secondRepairShopWayPoint, ReparingWaypoint.ReapirCarWayPoints 
        reparingCarWayPointsThirdCellCar,  FirstCarRepairWayPointParent firstCarRepairWayPointParent ,
        ParticleSystem particleSystem, ThirdWayPointParentForQueue  thirdWayPointParentForQueue, 
        SecondWashShopStateMachine secondWashShopStateMachine, ParticleSystem particleSystem1, Animator topPointAnimation) {
   
        _reapirCarWayPoints = reapirCarWayPoints;
        _stateMachine = stateMachine;
        _firstWayPoints = firstWayPoints;
        _inGarage = inGarage;
        _generalSpeed = generalSpeed;
        _secondRepairShopWayPoint = secondRepairShopWayPoint;
        this.reparingCarWayPointsThirdCellCar = reparingCarWayPointsThirdCellCar;
        _firstCarRepairWayPointParent = firstCarRepairWayPointParent;
        _particleSystem = particleSystem;
        _thirdWayPointParentForQueue = thirdWayPointParentForQueue;
        _secondWashShopStateMachine = secondWashShopStateMachine;
        _particleSystemSecond = particleSystem1;
        _topPointAnimation = topPointAnimation;
    }
    /// <summary>
    /// Read only properties
    /// </summary>
    public EskalatorWayPoint.EskalatorFirstWayPoints FirstWayPoints => _firstWayPoints;
    public EskalatorInteractionStateMachine EskalatorStateMachine => _stateMachine;
    public TransporterInGarage InGarage => _inGarage;
    public ReparingWaypoint.ReapirCarWayPoints ReapirCarWayPoints => _reapirCarWayPoints;
    public float GeneralSpeed => _generalSpeed;
    public ReparingWaypoint.ReapirCarWayPoints  SecondRepairShopWayPoint => _secondRepairShopWayPoint;

    public ReparingWaypoint.ReapirCarWayPoints ReparingCarWayPointsThirdCellCar => reparingCarWayPointsThirdCellCar;
    public FirstCarRepairWayPointParent FirstCarRepairWayPointParent => _firstCarRepairWayPointParent;
    public ParticleSystem ParticleSystem => _particleSystem;
     public ThirdWayPointParentForQueue ThirdWayPointParentForQueue => _thirdWayPointParentForQueue;
     public SecondWashShopStateMachine SecondWashShopStateMachine => _secondWashShopStateMachine;
    public ParticleSystem ParticleSystemSecond => _particleSystemSecond;
    public Animator TopPointAnimation => _topPointAnimation;
   }