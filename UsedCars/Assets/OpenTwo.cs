using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTwo : MonoBehaviour {
    [SerializeField] private Animator greenDoorAnimatot;
    private const string OPEN_TWO = "OpenTwo";
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            greenDoorAnimatot.SetBool(OPEN_TWO, true);

        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            greenDoorAnimatot.SetBool(OPEN_TWO, false);
        }
    }
}
