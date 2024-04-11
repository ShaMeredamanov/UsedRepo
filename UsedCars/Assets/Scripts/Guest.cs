using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Guest : MonoBehaviour {
    private float speed = 28f;
    private Vector3 _entrancePosition;
    private Vector3 _direction;
    private Action _isTrigered;
    private bool inEntrancePosition = false;
    public void MoveTo(Vector3 entrancePoition, Action? isTrigered = null) {
        _entrancePosition = entrancePoition;
        _direction = (entrancePoition - transform.position).normalized;
        _isTrigered = isTrigered;
    }
    private void Update() {
        transform.Translate(_direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, _entrancePosition) < 1f) {
            transform.position = _entrancePosition;
            _isTrigered?.Invoke();
        }
    }

}
