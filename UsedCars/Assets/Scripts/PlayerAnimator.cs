using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    private const string WORK = "Work";


    private void OnTriggerStay(Collider other) {
        if (other.TryGetComponent<FirstReceptionChooseCar>(out var firstReceptionChooseCar)) {
            if (_floatingJoystick.Horizontal != 0 && _floatingJoystick.Vertical != 0) {
                _playerAnimator.SetBool(WORK, true);
            } else {
                _playerAnimator.SetBool(WORK, false);
            }
        }
    }
}

