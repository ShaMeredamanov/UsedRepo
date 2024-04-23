using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerDjoystick : MonoBehaviour {
    private const string IS_RUN = "IsRun";
    private const string WORK = "Work";

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _floatingDjoystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private float _moveSpeed;
    
    private Vector3 currentPosition;
    private void LateUpdate() {
        _rigidbody.velocity = new Vector3(-_floatingDjoystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, -_floatingDjoystick.Vertical * _moveSpeed);

        if (transform.position.x > 315) {
            transform.position = new Vector3(315, transform.position.y, transform.position.z);
        } else if (transform.position.x < -197f) {
            transform.position = new Vector3(-197, transform.position.y, transform.position.z);
        } else if (transform.position.z < -380f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -380f);
        } else if (transform.position.z > 215f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 215f);
        }
        if (_floatingDjoystick.Horizontal != 0 || _floatingDjoystick.Vertical != 0) {
            _animator.SetBool(IS_RUN, true);
            _transformPlayer.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        } else {
            _animator.SetBool(IS_RUN, false);
        }

    }
    private void OnTriggerStay(Collider other) {
        if(other.TryGetComponent<FirstReceptionChooseCar>(out var firstReceptionChooseCar)) {
            if(_floatingDjoystick.Horizontal == 0 && _floatingDjoystick.Vertical == 0) {
                _animator.SetBool(WORK, true);
            } else {
                _animator.SetBool(WORK, false); 
            }
        } if(other.TryGetComponent<SecondReceptionSignContract>(out var secondReceptionChooseCar)) {
            if(_floatingDjoystick.Horizontal == 0 && _floatingDjoystick.Vertical == 0) {
                _animator.SetBool(WORK, true);
            } else {
                _animator.SetBool(WORK, false); 
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<FirstReceptionChooseCar>(out var firstReceptionChooseCar)) {
                _animator.SetBool(WORK, false); 
        }  if (other.TryGetComponent<SecondReceptionSignContract>(out var secondReceptionChooseCar)) {
                _animator.SetBool(WORK, false); 
        }
    }
}


