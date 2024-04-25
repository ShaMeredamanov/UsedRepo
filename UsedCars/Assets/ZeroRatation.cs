using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroRatation : MonoBehaviour {
    private void Update() {
        transform.localRotation= Quaternion.Euler(0f, 0f, 0f);  
    }
}
