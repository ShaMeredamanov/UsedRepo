using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EskalatorInteractionSellCar : EskalatorBaseIteractionState {
    public EskalatorInteractionSellCar(EskalatorContextState context, EskalatorInteractionStateMachine.EEskalatorInteractionState estate) : base(context, estate) {
        EskalatorContextState Context = context;
    }
    private const string IS_RUNNING = "IsRunning";



    private Transform repairCarWayPointsTransform;
    private ReparingWaypoint.ReapirCarWayPoints _reapirCarWayPoints;
    private Transform currentWayPoint;
    private Transform parentTransfrorm;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 2.5f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private bool isPeopleBuyed;
    private Coroutine rountine;
    private PeopleStateMachine _peopleStateMachine;
    public override void EnterState() {
        //  repairCarWayPointsTransform = EskalatorContext.ThirdWayPointParentForQueue.GetNExtQueue(EskalatorContext.EskalatorStateMachine, repairCarWayPointsTransform);
        //_reapirCarWayPoints = repairCarWayPointsTransform.GetComponent<ReparingWaypoint.ReapirCarWayPoints>();
        currentWayPoint = EskalatorContext.ReparingCarWayPointsThirdCellCar.GetNextWayPoint(currentWayPoint);
        parentTransfrorm = EskalatorContext.ReparingCarWayPointsThirdCellCar.GetThisComponentTransfrom(parentTransfrorm);
        childCount = parentTransfrorm.childCount;
        speed = 100;

        EskalatorContext.InGarage.GetCarObject().ChangeWHiteCarToNormalCar();
        EskalatorContext.SecondWashShopStateMachine.RemoveFromList();


        isPeopleBuyed = false;
    }
    public override void ExitState() {
    }
    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState() {
        if (childCount - 3 <= currentWayPoint.GetSiblingIndex()) {
            if (isPeopleBuyed) {
                speed = 100;
            } else {
                EskalatorContext.TopPointAnimation.SetBool(IS_RUNNING, true);
                speed = 0;
            }
        }
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex()) {
            EskalatorContext.EskalatorStateMachine.Destroy();

            EskalatorContext.TopPointAnimation.SetBool(IS_RUNNING, false);
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)) {
            EskalatorContext.ParticleSystem.Play();
            StartRoutine();
            _peopleStateMachine = peopleStateMachine;

          

        }
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
            currentWayPoint = EskalatorContext.ReparingCarWayPointsThirdCellCar.GetNextWayPoint(currentWayPoint);
        }
    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - EskalatorContext.EskalatorStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint - new Vector3(90, 0, 0));
        EskalatorContext.EskalatorStateMachine.transform.rotation = Quaternion.Slerp(EskalatorContext.EskalatorStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
    private void StartRoutine() {
        rountine = Coroutines.StartRoutine(WaitForAParticle());
    }
    private void StopRoutine() {

        Coroutines.StopRoutine(rountine);
    }

    private IEnumerator WaitForAParticle() {
        yield return new WaitForSecondsRealtime(0.40f);
        _peopleStateMachine.DestroyObject();
        _peopleStateMachine = null;
        isPeopleBuyed = true;
        StopRoutine();
    }

}
