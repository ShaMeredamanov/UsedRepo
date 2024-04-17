using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDoorOpenerTwo : MonoBehaviour {
    [SerializeField] private Animator yellowDoorAnimatot;
    private const string OPEN_TWO = "OpenTwo";
    private void OnTriggerEnter(Collider other) {
        yellowDoorAnimatot.SetBool(OPEN_TWO, true);



    }
    private void OnTriggerExit(Collider other) {
        yellowDoorAnimatot.SetBool(OPEN_TWO, false);

    }
}
