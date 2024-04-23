using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionSecondRepairShopState : EskalatorBaseIteractionState {
    public EskalatorInteractionSecondRepairShopState(EskalatorContextState eskalatorContext, EskalatorInteractionStateMachine.EEskalatorInteractionState estate) : base(eskalatorContext, estate) {
        EskalatorContextState contextState = eskalatorContext;

    }
    private Transform currentWayPoint;
    private float speed;
    private float distanceThreeShold = 2.5f;
    private float timer = 5f;
    private float timerMax = 5f;
    public override void EnterState() {
        currentWayPoint = EskalatorContext.SecondRepairShopWayPoint.GetNextWayPoint(currentWayPoint);
        speed = EskalatorContext.GeneralSpeed;
        EskalatorContext.InGarage.GetCarObject().ChangeDurtyCarToWHiteCar();
    }

    public override void ExitState() {
    }

    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState() {
        if (EskalatorContext.SecondRepairShop.PlayerDjoystick != null) {
            if (!EskalatorContext.SecondRepairShop.SecondReceptionSignContract.CanGetClient()) {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                  
                    timer = timerMax;
                    return EskalatorInteractionStateMachine.EEskalatorInteractionState.SellCar;
                }
            }
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
    }

    public override void OnTriggerExit(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other) {
        throw new System.NotImplementedException();
    }

    public override void UpdateState() {
        var direction = (currentWayPoint.transform.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        EskalatorContext.EskalatorStateMachine.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(EskalatorContext.EskalatorStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            currentWayPoint = EskalatorContext.SecondRepairShopWayPoint.GetNextWayPoint(currentWayPoint);
        }
        if (Vector3.Distance(EskalatorContext.EskalatorStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            speed = 0;
        } else {
            speed = 80;
        }
    }
}
