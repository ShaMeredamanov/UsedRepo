using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PeopleInteractionFirstChooseCar : PeopleBaseInteractionState {

    public PeopleInteractionFirstChooseCar(PeopleContextState peopleContext, PeopleStateMachine.EPoepleInteractionState state) : base(peopleContext, state) {

        PeopleContextState peopleContextState = peopleContext;
    }

    public static Action OnBuyerChooseCar;

    private Transform walkingWayPointParentTransform;
    private WayPointForCars _wayPointForCars;
    private Transform currentCarsWayPoint;
    private Transform currentWayPoint;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 1f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float timer = 3f;
    private float timerMax = 3f;
    private float rotateSpeed = 10f;
    private const string IS_WALKING = "IsWalking";
    private bool canChangeState;
    private int getMoney;
    private bool onBuyernearCar;
    private GameObject _imageObject;
    private Image _image;
    private float fillAmount;
    private Coroutine _coroutine;
    public override void EnterState() {
        onBuyernearCar = false;
        canChangeState = false;
        currentCarsWayPoint = PeopleContext.CarsParentPoint.GetCurrentCarsWayPoint(currentCarsWayPoint);
        getMoney = PeopleContext.CarsParentPoint.GetMoneyWithTransform(currentCarsWayPoint);
        PeopleContext.PeopleStateMachine.GetCurrentMoney(getMoney);
        _wayPointForCars = currentCarsWayPoint.GetComponent<WayPointForCars>();
        _wayPointForCars.GetPeopleStateMachine(PeopleContext.PeopleStateMachine);
        walkingWayPointParentTransform = _wayPointForCars.GetWayPointForCarsTransform(walkingWayPointParentTransform);
        childCount = walkingWayPointParentTransform.childCount;
        currentWayPoint = _wayPointForCars.GetNextWayPoint(currentWayPoint);
        speed = PeopleContext.GeneralSpeed;
        PeopleContext.Animator.SetBool(IS_WALKING, true);


    }

    public override void ExitState() {
        StopCoroutine();
    }

    public override PeopleStateMachine.EPoepleInteractionState GetNextState() {
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex()) {
            speed = 0;
            PeopleContext.Animator.SetBool(IS_WALKING, false);
          if(_imageObject != null) {
                _imageObject.SetActive(true);
                _image.gameObject.SetActive(true);
            }
         
            if (!onBuyernearCar) {
                onBuyernearCar = true;
                OnBuyerChooseCar?.Invoke();
            }
        }
        if (canChangeState) {
            canChangeState = false;
            Debug.Log("walk car side");
            if (PeopleContext.ReceptionChooseCarStateMachine.PeopleStateMachinesList.Count < 2) {
                return PeopleStateMachine.EPoepleInteractionState.WalkCarSideState;
            }
        }
        return StateKey;
    }
    public override void OnTriggerEnter(Collider other) {
        StartCoroutine();
    }
    public override void OnTriggerExit(Collider other) {
        StopCoroutine();
    }
    public override void OnTriggerStay(Collider other) {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = timerMax;
            canChangeState = true;
            StopCoroutine();
            var collider = PeopleContext.PeopleStateMachine.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public override void UpdateState() {
        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        PeopleContext.PeopleStateMachine.transform.Translate(diretionToWayPoint * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(PeopleContext.PeopleStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            if (childCount - 1 > currentWayPoint.GetSiblingIndex()) {
                currentWayPoint = _wayPointForCars.GetNextWayPoint(currentWayPoint);
            }
        }
        RotateTowardsWayPoint();
    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - PeopleContext.PeopleStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint);
        PeopleContext.PeopleStateMachine.transform.rotation = Quaternion.Slerp(PeopleContext.PeopleStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
    private void StartCoroutine() {
        if (this._coroutine != null)
            return;

        _imageObject = PeopleContext.SalesAgentCellCar.GetNewGameObject(_imageObject);
        _image = PeopleContext.SalesAgentCellCar.GetNewImage(_image);
        fillAmount = 0;
        _image.fillAmount = 0;
        timer = timerMax;
        _coroutine = Coroutines.StartRoutine(CalculateTime());
    }
    private void StopCoroutine() {
        Coroutines.StopRoutine(_coroutine);
        _image.gameObject.SetActive(false);
        _imageObject.SetActive(false);
        fillAmount = 0;
        _image.fillAmount = 0;
        _coroutine = null;
    }
    private IEnumerator CalculateTime() {
        while (true) {
            if (fillAmount < 1f) {
                fillAmount += (float)0.0150f;
                _image.fillAmount = (float)fillAmount;
                yield return new WaitForSeconds(0.03f);
            } else {
                yield return null;
            }
        }
    }
}
