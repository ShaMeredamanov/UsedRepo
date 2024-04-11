using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerDjoystick : MonoBehaviour {



    private const string IS_RUN = "IsRun";

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _floatingDjoystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private float _moveSpeed;
    private Vector3 currentPosition;
    private void LateUpdate() {
        _rigidbody.velocity = new Vector3(-_floatingDjoystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, -_floatingDjoystick.Vertical * _moveSpeed);
        if (transform.position.x > 325) {
            transform.position = new Vector3(325, transform.position.y, transform.position.z);
        } else if (transform.position.x < -209f) {
            transform.position = new Vector3(-209, transform.position.y, transform.position.z);
        } else if (transform.position.z < -280f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -280f);
        } else if (transform.position.z > 115f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 115f);
        }
        if (_floatingDjoystick.Horizontal != 0 || _floatingDjoystick.Vertical != 0) {
            _animator.SetBool(IS_RUN, true);
            _transformPlayer.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        } else {
            _animator.SetBool(IS_RUN, false);
        }

    }
}


