using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignContractWayPoint : MonoBehaviour {
    private void OnDrawGizmos() {
        foreach (Transform t in transform) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(t.position, 1f);
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++) {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
    }
    public Transform GetNextWayPoint(Transform currentWayPoint) {
        if (currentWayPoint == null) {

            return transform.GetChild(0);
        }
        if (currentWayPoint.GetSiblingIndex() < transform.childCount - 1) {
            return transform.GetChild(currentWayPoint.GetSiblingIndex() + 1);
        } else {
            return transform.GetChild(0);
        }
    }
    public Transform GetThisComponentTransfrom(Transform currentTransfrom) {
        currentTransfrom = transform;
        return currentTransfrom;
    }
}
