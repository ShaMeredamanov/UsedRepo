using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionRapairCar : EskalatorBaseIteractionState
{/// <summary>
///Constructor 
/// </summary>
/// <param name="context"></param>
/// <param name="estate"></param>
    public EskalatorInteractionRapairCar(EskalatorContextState context, EskalatorInteractionStateMachine.EEskalatorInteractionState estate) : base(context, estate)
    {
        EskalatorContextState Context = context;
    }
    /// <summary>
    /// At the moment i just put second when i get crash car i changed it with crash car after chnage state
    /// </summary>

    private ReparingWaypoint.ReapirCarWayPoints reapirCarWayPoints;
    private Transform currentWayPoint;
    private Transform parentTransfrorm;
    private Transform parentRepairWayPoint;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 0.5f;
    private int index;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private float timer = 10f;
    private float timerMax = 10f;
    public override void EnterState()
    {
        currentWayPoint = EskalatorContext.ReapirCarWayPoints.GetNextWayPoint(currentWayPoint);
        parentTransfrorm = EskalatorContext.ReapirCarWayPoints.GetThisComponentTransfrom(parentTransfrorm);
        childCount = parentTransfrorm.childCount;
        speed = EskalatorContext.GeneralSpeed;

    }

    public override void ExitState()
    {
    }

    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState()
    {
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex())
        {
            return EskalatorInteractionStateMachine.EEskalatorInteractionState.SellCar;
        }
        return StateKey;
    }

    public override void UpdateState()
    {
        var direction = (currentWayPoint.transform.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        EskalatorContext.EskalatorStateMachine.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(EskalatorContext.EskalatorStateMachine.transform.position, currentWayPoint.position) < distanceThreeShold)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                index++;
                currentWayPoint = EskalatorContext.ReapirCarWayPoints.GetNextWayPoint(currentWayPoint);
                timer = timerMax;
                switch (index)
                {
                    case 1:
                        EskalatorContext.InGarage.GetCarObject().ChangeDurtyCarToWHiteCar();
                        break;
                    case 2:
                        EskalatorContext.InGarage.GetCarObject().ChangeWHiteCarToNormalCar();
                        break;
                }
            }
        }
        if (Vector3.Distance(EskalatorContext.EskalatorStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold)
        {
            speed = 0;
        }
        else
        {
            speed = 80;
        }
     //  RotateTowardsWayPoint();
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }
    private void RotateTowardsWayPoint()
    {
        diretionToWayPoint = (currentWayPoint.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(-diretionToWayPoint);
        EskalatorContext.EskalatorStateMachine.transform.rotation = Quaternion.Slerp(EskalatorContext.EskalatorStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
