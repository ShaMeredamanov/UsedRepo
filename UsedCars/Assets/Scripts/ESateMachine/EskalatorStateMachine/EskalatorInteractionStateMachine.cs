using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionStateMachine : StateManager<EskalatorInteractionStateMachine.EEskalatorInteractionState> {
    public enum EEskalatorInteractionState {
        SecondReapairShop,
        WaitCarState,
        MoveGarage,
        RepairState,
        SellCar,
    }
    [SerializeField] private EskalatorWayPoint.EskalatorFirstWayPoints eskalatorWayPoint;
    [SerializeField] private ReparingWaypoint.ReapirCarWayPoints _reapirCarWayPoints;
    [SerializeField] private ParentConveinerWayPoint.ParentConveinerWayPoint parentConveiner;
    [SerializeField] private ReparingWaypoint.ReapirCarWayPoints reparingCarWayPointsSecond;
    [SerializeField] private ReparingWaypoint.ReapirCarWayPoints reparingCarWayPointsThirdCellCar;
    [SerializeField] private FirstRepiarShop _firstReapirShop;
    [SerializeField] private SecondRepairShop _secondRepairShop;
    [SerializeField] private Transform _topPoint;
    
    
    private EskalatorContextState _eskalatorContext;
    private TransporterInGarage _inGarage;
    private float generalSpeed = 80f;

    private void Awake() {
        _inGarage = GetComponent<TransporterInGarage>();
        _eskalatorContext = new EskalatorContextState(eskalatorWayPoint, _inGarage, _reapirCarWayPoints, parentConveiner, generalSpeed, this, reparingCarWayPointsSecond, reparingCarWayPointsThirdCellCar, _firstReapirShop, _secondRepairShop);
        InitilizeStates();
    }
    private void InitilizeStates() {
        States.Add(EEskalatorInteractionState.WaitCarState, new EskaltorInteractionWaitCarState(_eskalatorContext, EEskalatorInteractionState.WaitCarState));
        States.Add(EEskalatorInteractionState.MoveGarage, new EskalatorInteractionMoveGarage(_eskalatorContext, EEskalatorInteractionState.MoveGarage));
        States.Add(EEskalatorInteractionState.RepairState, new EskalatorInteractionRapairCar(_eskalatorContext, EEskalatorInteractionState.RepairState));
        States.Add(EEskalatorInteractionState.SellCar, new EskalatorInteractionSellCar(_eskalatorContext, EEskalatorInteractionState.SellCar));
        States.Add(EEskalatorInteractionState.SecondReapairShop, new EskalatorInteractionSecondRepairShopState(_eskalatorContext, EEskalatorInteractionState.SecondReapairShop));
        CurrentState = States[EEskalatorInteractionState.WaitCarState];
    }
    public bool CheckEskalatorState() {
        return CurrentState == States[EEskalatorInteractionState.RepairState];
    }
    public bool CheckEskalatorStateIsCellCarState() {
        return CurrentState == States[EEskalatorInteractionState.SellCar];
    }
    private CarObject GetCarObjectFromTopPoint() {
        CarObject carObject = _topPoint.GetChild(0).GetComponent<CarObject>();
        return carObject;
    }
    private void OnTriggerEnter(Collider other) {
        CurrentState.OnTriggerEnter(other);
    }
    public void Destroy() {
        Destroy(gameObject);
    }
}
