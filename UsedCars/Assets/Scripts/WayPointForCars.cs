using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointForCars : MonoBehaviour {
    private void OnDrawGizmos() {
        foreach (Transform t in transform) {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(t.position, 10f);
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++) {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
    }
    /// <summary>
    /// Start from here
    /// </summary>
    /// <param name="currentChild"></param>
    /// <returns></returns>
    /// 
    private PeopleStateMachine _peopleStateMachine;
    [SerializeField] private Transform _currentCars;
    public Transform GetNextWayPoint(Transform currentChild) {
        if (currentChild == null) {
            return transform.GetChild(0);
        }
        if (currentChild.GetSiblingIndex() < transform.childCount - 1) {
            return transform.GetChild(currentChild.GetSiblingIndex() + 1);
        } else {
            return transform.GetChild(0);
        }


    }
    public PeopleStateMachine GetPeopleStateMachine(PeopleStateMachine peopleStateMachine) {
        _peopleStateMachine = peopleStateMachine;
        return _peopleStateMachine;
    }

    public Transform GetWayPointForCarsTransform(Transform current) {
        current = transform;
        return current;
    }
    public Transform GetCurrentCar(Transform currentCar) {
        currentCar = _currentCars;
        return _currentCars;
    }
}
