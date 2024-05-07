using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionStateMachine : StateManager<EskalatorInteractionStateMachine.EEskalatorInteractionState> {
    public enum EEskalatorInteractionState {
        SecondReapairShop,
        WaitCarState,
        MoveGarage,
        RepairState,
        BeforeCellCar,
        SellCar,
    }
    [SerializeField] private EskalatorWayPoint.EskalatorFirstWayPoints eskalatorWayPoint;
    [SerializeField] private FirstCarRepairWayPointParent _firstCarRepairWayPointParent;
    [SerializeField] private ReparingWaypoint.ReapirCarWayPoints _reapirCarWayPoints;
    [SerializeField] private ReparingWaypoint.ReapirCarWayPoints reparingCarWayPointsSecond;
    [SerializeField] private ReparingWaypoint.ReapirCarWayPoints reparingCarWayPointsThirdCellCar;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ParticleSystem _particleSystemSecond;
    [SerializeField] private Transform _topPoint;
    [SerializeField] private ThirdWayPointParentForQueue _thirdWayPointParent;
    [SerializeField] private SecondWashShopStateMachine _secondWashShopStateMachine;
    [SerializeField] private Animator _topPointAnimations;
    private EskalatorContextState _eskalatorContext;
    private TransporterInGarage _inGarage;
    private float generalSpeed = 80f;
    private bool getWayPointAgain;
    private void Awake() {
        _inGarage = GetComponent<TransporterInGarage>();
        _eskalatorContext = new EskalatorContextState(eskalatorWayPoint, _inGarage, _reapirCarWayPoints, generalSpeed, this,
            reparingCarWayPointsSecond, reparingCarWayPointsThirdCellCar, _firstCarRepairWayPointParent, 
            _particleSystem, _thirdWayPointParent, _secondWashShopStateMachine, _particleSystemSecond, _topPointAnimations);
        InitilizeStates();
    }
    private void InitilizeStates() {
        States.Add(EEskalatorInteractionState.WaitCarState, new EskaltorInteractionWaitCarState(_eskalatorContext, EEskalatorInteractionState.WaitCarState));
        States.Add(EEskalatorInteractionState.MoveGarage, new EskalatorInteractionMoveGarage(_eskalatorContext, EEskalatorInteractionState.MoveGarage));
        States.Add(EEskalatorInteractionState.RepairState, new EskalatorInteractionRapairCar(_eskalatorContext, EEskalatorInteractionState.RepairState));
        States.Add(EEskalatorInteractionState.SecondReapairShop, new EskalatorInteractionSecondRepairShopState(_eskalatorContext, EEskalatorInteractionState.SecondReapairShop));
        States.Add(EEskalatorInteractionState.BeforeCellCar, new EskalatorInteractionBeforeCellCar(_eskalatorContext, EEskalatorInteractionState.BeforeCellCar));
        States.Add(EEskalatorInteractionState.SellCar, new EskalatorInteractionSellCar(_eskalatorContext, EEskalatorInteractionState.SellCar));
        CurrentState = States[EEskalatorInteractionState.WaitCarState];
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)) {
            CurrentState.OnTriggerEnter(other);
        }
    }
    public void Destroy() {
        Destroy(gameObject);
    }
    public void ChangeState() {
        CurrentState = States[EEskalatorInteractionState.SecondReapairShop];
        CurrentState.EnterState();
    }
    public void ChangeStateToSellCarState() {
        CurrentState = States[EEskalatorInteractionState.SellCar];
        CurrentState.EnterState();
    }
    public void GetWayPointAgainToTrue() {
        getWayPointAgain = true;
    }
    public void GetWayPointAgainToFalse() {
        getWayPointAgain = false;
    }
    public bool GetWayPointAgain() {
        return getWayPointAgain;
    }
}
