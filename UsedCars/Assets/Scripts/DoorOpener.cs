using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine.Utility;
public class DoorOpener : MonoBehaviour {
    [SerializeField] private Animator greenDoorAnimatot;
    private const string OPEN_DOOR = "OpenDoor";
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            greenDoorAnimatot.SetBool(OPEN_DOOR, true);

        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            greenDoorAnimatot.SetBool(OPEN_DOOR, false);
        }
    }
}
