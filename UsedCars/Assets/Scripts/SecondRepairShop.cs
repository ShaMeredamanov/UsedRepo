using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRepairShop : MonoBehaviour, IRepairShopParent {

    private const string WASH = "Wash";

    private const string WORK = "Work";

    [SerializeField] private Transporter _transporter;
    [SerializeField] private SecondReceptionSignContract _signContract;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _washAnimator;
    [SerializeField] private List<EskalatorInteractionStateMachine> _eskalatorStateMachineList;
    private EskalatorInteractionStateMachine _eskalatorStateMachine;
    private PlayerDjoystick _playerDjoystick;
    private float timer = 5f;
    private float timerMax = 5f;
    private bool hasCar;
    public void ClearCar() {
        _eskalatorStateMachine = null;
    }
    public void GetCar(Transform transform) {
    }
    public bool HasCar() {
        return _eskalatorStateMachine != null;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorStateMachine)) {
            hasCar = true;
            _eskalatorStateMachineList.Add(eskalatorStateMachine);
        }
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            if (!_signContract.CanGetClient()) {
                _playerDjoystick = playerDjoystick;
            }
        }
    }
    private void OnTriggerStay(Collider other) {

        if (_playerDjoystick != null) {
            if (hasCar) {

                _washAnimator.SetBool(WASH, true);
                _playerAnimator.SetBool(WORK, true);
            } else {
                _washAnimator.SetBool(WASH, false);

                _playerAnimator.SetBool(WORK, false);
            }
            timer -= Time.deltaTime;
            if (timer < 0) {
                ClearCar();
                timer = timerMax;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = null;
            timer = timerMax;
            _playerAnimator.SetBool(WORK, false);
        }
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorStateMachine)) {
            _eskalatorStateMachine = eskalatorStateMachine;
            timer = timerMax;
            hasCar = false;
        }
    }
    public void RemoveFromList() {
        _eskalatorStateMachineList.RemoveAt(0);
    }
    /// <summary>
    /// Read only properties
    /// </summary>
    public EskalatorInteractionStateMachine EskalatorInteractionStateMachine => _eskalatorStateMachine;
    /// <summary>
    /// Read only properties
    /// </summary>
    /// <returns></returns>
    public PlayerDjoystick PlayerDjoystick => _playerDjoystick;
    public SecondReceptionSignContract SecondReceptionSignContract => _signContract;
    public List<EskalatorInteractionStateMachine> EskalatorInteractionStateMachineList => _eskalatorStateMachineList;
}
