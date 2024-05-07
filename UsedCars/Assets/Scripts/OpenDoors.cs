using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {
    private const string OPEN_DOOR = "OpenDoor";
    private const string OPEN_TWO = "OpenTwo";
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private BoxCollider _boxCollider2;
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            if (other.bounds.Intersects(_boxCollider.bounds)) {
                _doorAnimator.SetBool(OPEN_DOOR, true);
            }else if (other.bounds.Intersects(_boxCollider2.bounds)) {
                _doorAnimator.SetBool(OPEN_TWO, true);
            }
        }
        if(other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)) {
            if (other.bounds.Intersects(_boxCollider.bounds)) {
                _doorAnimator.SetBool(OPEN_DOOR, true);
            } else if (other.bounds.Intersects(_boxCollider2.bounds)) {
                Debug.Log("2");
                _doorAnimator.SetBool(OPEN_TWO, true);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
                _doorAnimator.SetBool(OPEN_TWO, false);
                _doorAnimator.SetBool(OPEN_DOOR, false);
        }
        if (other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)) {
            _doorAnimator.SetBool(OPEN_TWO, false);
            _doorAnimator.SetBool(OPEN_DOOR, false);


        }
    }
}
