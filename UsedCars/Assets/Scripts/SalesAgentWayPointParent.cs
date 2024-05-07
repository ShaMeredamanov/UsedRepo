using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesAgentWayPointParent : MonoBehaviour {

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
    public Transform GetThisComponentTransform(Transform parentTransform) {
        parentTransform = transform;
        return parentTransform;
    }

}
