using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDoorOpener : MonoBehaviour
{
    [SerializeField] private Animator yellowDoorAnimatot;
    private const string OPEN_DOOR = "OpenDoor";
    private void OnTriggerEnter(Collider other) {
       yellowDoorAnimatot.SetBool(OPEN_DOOR, true);

        
    }
    private void OnTriggerExit(Collider other) {
            yellowDoorAnimatot.SetBool(OPEN_DOOR, false);
        
    }
}
