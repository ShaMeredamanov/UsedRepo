using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SalesAgentInteractionTalkWithClent : SalesAgentBaseState {

    public SalesAgentInteractionTalkWithClent(SalesAgentContextState salesAgentContextState, SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine statekey) : base(salesAgentContextState, statekey) {
        SalesAgentContextState salesAgentContextState1 = salesAgentContextState;
    }

    private const string IS_WALKING = "IsWalking";

    private Transform walkingWayPointParentTransform;
    private CarsParentPoint _carsParentPoint;
    private WayPointForCars _wayPointForCars;
    private Transform currentCarsWayPoint;
    private Transform currentWayPoint;
    private int childCount;
    private float speed;
    private float distanceThreeShold = 1f;
    private Vector3 diretionToWayPoint;
    private Quaternion rotationGoal;
    private float rotateSpeed = 10f;
    private Image _image;
    private float fillAmount;
    private float timer;
    private Coroutine coroutine;
    private GameObject gameObjectImage;
    private bool routine;
    public override void EnterState() {
        routine = false;
        timer = SalesAgentContext.SalesAgentStateMachine.Timer;
      //  gameObjectImage = SalesAgentContext.SalesAgentCellCars.GetNewGameObject(gameObjectImage);
        currentCarsWayPoint = SalesAgentContext.SalesAgentCellCars.GetMextWayPoint(currentCarsWayPoint);
 //       _image = SalesAgentContext.SalesAgentCellCars.GetNewImage(_image);
    //    _image.fillAmount = 0f;
   //     fillAmount = 0f;
    //    Debug.Log(_image.name, _image);
        _wayPointForCars = currentCarsWayPoint.GetComponent<WayPointForCars>();
        walkingWayPointParentTransform = _wayPointForCars.GetWayPointForCarsTransform(walkingWayPointParentTransform);
        currentWayPoint = _wayPointForCars.GetNextWayPoint(currentWayPoint);
        speed = 30f;

        SalesAgentContext.SalesAgentAnimator.SetBool(IS_WALKING, true);
        childCount = walkingWayPointParentTransform.childCount;
    }

    public override void ExitState() {
     //   _image.gameObject.SetActive(false);
    //    StopCoroutine();
    //    gameObjectImage.SetActive(false);
    //    _image = null;
    }

    public override SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine GetNextState() {
        if (SalesAgentContext.ReceptionChooseCarStateMachine.PeopleStateMachinesList[0].CheckStateIsStateInsideRoom()) {
            

            return SalesAgentInteractionStateMachine.ESalesAgentInteractionStateMachine.Vacand;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)){

          
        }
    }

    public override void OnTriggerExit(Collider other) {
     

    }

    public override void OnTriggerStay(Collider other) {

    }

    public override void UpdateState() {
        var direction = (currentWayPoint.transform.position - SalesAgentContext.SalesAgentStateMachine.transform.position).normalized;
        SalesAgentContext.SalesAgentStateMachine.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex()) {
            speed = 0;
            if (!routine) {
           //     StartCoroutine();
             routine = true;
            }
            SalesAgentContext.SalesAgentAnimator.SetBool(IS_WALKING, false);
        } else if (Vector3.Distance(SalesAgentContext.SalesAgentStateMachine.transform.position, currentWayPoint.position) <= distanceThreeShold) {
            currentWayPoint = _wayPointForCars.GetNextWayPoint(currentWayPoint);
            speed = 30f;            
            SalesAgentContext.SalesAgentAnimator.SetBool(IS_WALKING, true);
        }
        RotateTowardsWayPoint();
    }
    private void RotateTowardsWayPoint() {
        diretionToWayPoint = (currentWayPoint.position - SalesAgentContext.SalesAgentStateMachine.transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(diretionToWayPoint);
        SalesAgentContext.SalesAgentStateMachine.transform.rotation = Quaternion.Slerp(SalesAgentContext.SalesAgentStateMachine.transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
    private void StartCoroutine() {
    }
    private void StopCoroutine() {
        Coroutines.StopRoutine(coroutine);
    }
    private IEnumerator CalculateTime() {
        while (true) {
            if (fillAmount < 1f) {
                Debug.Log("not work");
                fillAmount += (float)0.0150f;
                _image.fillAmount = (float)fillAmount;
                yield return new WaitForSeconds(SalesAgentContext.SalesAgentStateMachine.Upgrade);
            } else {
                yield return null;
            }
        }
    }
}