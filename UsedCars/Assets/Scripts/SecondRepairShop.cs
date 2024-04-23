using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRepairShop : MonoBehaviour {
    private const string WASH = "Wash";
    [SerializeField] private Transporter _transporter;
    [SerializeField] private SecondReceptionSignContract _signContract;
    [SerializeField] private Animator _washAnimator;
    [SerializeField] private List<EskalatorInteractionStateMachine> _eskalatorStateMachineList;
    private PlayerDjoystick _playerDjoystick;
    private float timer = 5f;
    private float timerMax = 5f;
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
                _playerDjoystick = playerDjoystick;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (_playerDjoystick != null) {
            if (_eskalatorStateMachineList.Count > 0) {
                if (_eskalatorStateMachineList[0] != null) {
                    _washAnimator.SetBool(WASH, true);
                } else {
                    _washAnimator.SetBool(WASH, false);
                }
            }
            timer -= Time.deltaTime;
            if (timer < 0) {
                timer = timerMax;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = null;
            timer = timerMax;
            _washAnimator.SetBool(WASH, false);
        }
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorStateMachine)) {
            timer = timerMax;
            _washAnimator.SetBool(WASH, false);
        }
    }
    public void RemoveFromList() {
        _eskalatorStateMachineList.RemoveAt(0);
    }
    public void GetEskalatorToList(EskalatorInteractionStateMachine eskalatorInteractionState) {
        _eskalatorStateMachineList.Add(eskalatorInteractionState);
    }
    /// <summary>
    /// Read only properties
    /// </summary>
    /// <returns></returns>
    public PlayerDjoystick PlayerDjoystick => _playerDjoystick;
    public SecondReceptionSignContract SecondReceptionSignContract => _signContract;
    public List<EskalatorInteractionStateMachine> EskalatorInteractionStateMachineList => _eskalatorStateMachineList;
}
