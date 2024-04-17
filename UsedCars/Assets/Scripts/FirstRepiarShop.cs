using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FirstRepiarShop : MonoBehaviour, IRepairShopParent {

    private const string REPAIR = "Repair";
    private const string WORK = "Work";


    [SerializeField] private Transporter _transporter;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Animator _reapairAnimator;
    [SerializeField] private Animator _playerAnimator;
    private EskalatorInteractionStateMachine _interactionStateMachine;
    private PlayerDjoystick _playerDjoystick;
    private CarObject _currentCar;
    private float timer = 5f;
    private float timerMax = 5f;
    private bool hasCar;
    private void Start() {
        StartCoroutine(GetCarNumerator());
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
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionState)) {
            _interactionStateMachine = eskalatorInteractionState;
            hasCar = true;
        }
    }
    private void OnTriggerStay(Collider other) {

        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            if (hasCar) {
                _reapairAnimator.SetBool(REPAIR, true);
                _playerAnimator.SetBool(WORK, true);

            } else {

                _playerAnimator.SetBool(WORK, false);
                _reapairAnimator.SetBool(REPAIR, false);
            }
        }
            if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalator)) {
                if (_playerDjoystick != null) {
                    timer -= Time.deltaTime;
                    if (timer < 0) {
                        ClearCar();
                        timer = timerMax;
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other) {
            if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionState)) {
                ClearCar();
                timer = timerMax;
            hasCar = false;
            }
            if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
                _playerDjoystick = null;
                timer = timerMax;

            _playerAnimator.SetBool(WORK, false);
        }
        }

        private IEnumerator GetCarNumerator() {
            yield return new WaitForSecondsRealtime(0.5f);
            GetCar(transform);
        }
    }
