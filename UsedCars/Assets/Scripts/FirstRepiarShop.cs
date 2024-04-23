using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRepiarShop : MonoBehaviour, IRepairShopParent {

    private const string REPAIR = "Repair";

    [SerializeField] private Transporter _transporter;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Animator _reapairAnimator;
    [SerializeField] private SecondRepairShop _secondRepairShop;
    [SerializeField] private List<EskalatorInteractionStateMachine> _eskalatorInteractionList;
    private EskalatorInteractionStateMachine stateMachineEskalator;
    [SerializeField] private FirstCarRepairWayPointParent _firstCarRepairWayPointParent;
    private PlayerDjoystick _playerDjoystick;
    private CarObject _currentCar;
    private float timer = 5f;
    private float timerMax = 5f;
    private void Start() {
        StartCoroutine(GetCarNumerator());
        _eskalatorInteractionList = new List<EskalatorInteractionStateMachine>();
    }
    public void ClearCar() {
        _currentCar = null;
    }
    public void GetCar(Transform transform) {
        _currentCar = _transporter.CarTransform.GetComponent<CarObject>();
    }
    public bool HasCar() {
        return _currentCar != null;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = playerDjoystick;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalator)) {
            if (_playerDjoystick != null) {
                timer -= Time.deltaTime;
                _reapairAnimator.SetBool(REPAIR, true);
                if (timer < 0) {
                    if (_secondRepairShop.EskalatorInteractionStateMachineList.Count < 1) {
                        _eskalatorInteractionList[0].GetComponent<EskalatorInteractionStateMachine>().ChangeState();
                        ClearCar();
                        timer = timerMax;
                    } else {
                        timer = timerMax;
                    }
                }
            } else {
                _reapairAnimator.SetBool(REPAIR, false); 

            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionState)) {
            _secondRepairShop.GetEskalatorToList(eskalatorInteractionState);
            RemoveFromEsklatorList(eskalatorInteractionState);
            ClearCar();
            timer = timerMax;
            _reapairAnimator.SetBool(REPAIR, false);
        }
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = null;
            timer = timerMax;
            _reapairAnimator.SetBool(REPAIR, false);
        }
    }
    private IEnumerator GetCarNumerator() {
        yield return new WaitForSecondsRealtime(0.5f);
        GetCar(transform);
    }
    public void TransporterIngarage(TransporterInGarage transporterInGarage) {
        EskalatorInteractionStateMachine eskaltorStateMachine = transporterInGarage.StateMachineEskaltor();
        GetEsKalatorINteractionStateMachine(eskaltorStateMachine);
    }
    private void GetEsKalatorINteractionStateMachine(EskalatorInteractionStateMachine eskalatorInteractionStateMachine) {
        stateMachineEskalator = eskalatorInteractionStateMachine;
        _eskalatorInteractionList.Add(stateMachineEskalator);
    }
    public void RemoveFromEsklatorList(EskalatorInteractionStateMachine eskalatorInteractionStateMachine) {
        var index = _eskalatorInteractionList.IndexOf(eskalatorInteractionStateMachine);
        _eskalatorInteractionList.RemoveAt(index);
        _firstCarRepairWayPointParent.DecrementIndex();

        foreach (EskalatorInteractionStateMachine eskalatorInteractionState in _eskalatorInteractionList) {
            eskalatorInteractionState.GetWayPointAgainToTrue();
        }
    }
}
