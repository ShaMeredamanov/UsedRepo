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
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ParticleSystem _particleSystemSecond;

    private Vector3 currentPosition;
    private void LateUpdate() {
        _rigidbody.velocity = new Vector3(-_floatingDjoystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, -_floatingDjoystick.Vertical * _moveSpeed);

        if (transform.position.x > 309) {
            transform.position = new Vector3(309, transform.position.y, transform.position.z);
        } else if (transform.position.x < -197f) {
            transform.position = new Vector3(-197, transform.position.y, transform.position.z);
        } else if (transform.position.z < -270f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -270f);
        } else if (transform.position.z > 215f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 215f);
        }
        if (_floatingDjoystick.Horizontal != 0 || _floatingDjoystick.Vertical != 0) {
            _animator.SetBool(IS_RUN, true);
            var rotation = Vector3.RotateTowards(transform.forward, _rigidbody.velocity, 10f * Time.deltaTime, 0.0f);
            var targetRoatation = _rigidbody.velocity.normalized;
            targetRoatation.y = 0;
            _transformPlayer.rotation = Quaternion.LookRotation(targetRoatation);
            _particleSystem.Play();
            _particleSystemSecond.Play();
        } else {
            _animator.SetBool(IS_RUN, false);
            _particleSystem.Stop();
            _particleSystemSecond.Stop();
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.TryGetComponent<FirstReceptionChooseCar>(out var firstReceptionChooseCar)) {
            if (_floatingDjoystick.Horizontal == 0 && _floatingDjoystick.Vertical == 0) {
                _animator.SetBool(WORK, true);
            } else {
                _animator.SetBool(WORK, false);
            }
        }
        if (other.TryGetComponent<SecondReceptionSignContract>(out var secondReceptionChooseCar)) {
            if (_floatingDjoystick.Horizontal == 0 && _floatingDjoystick.Vertical == 0) {
                _animator.SetBool(WORK, true);
            } else {
                _animator.SetBool(WORK, false);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<FirstReceptionChooseCar>(out var firstReceptionChooseCar)) {
            _animator.SetBool(WORK, false);
        }
        if (other.TryGetComponent<SecondReceptionSignContract>(out var secondReceptionChooseCar)) {
            _animator.SetBool(WORK, false);
        }
    }
}


