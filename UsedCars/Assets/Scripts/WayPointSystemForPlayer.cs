using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointSystemForPlayer : MonoBehaviour
{
    private Transform _currentChild;
    public WayPointSystemForPlayer(Transform currrentChild)
    {
        _currentChild = currrentChild;
    }
    private void OnDrawGizmos() {
        foreach (Transform t in transform) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(t.position, 10f);
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++) {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
    }
    public Transform GetChildObject(Transform currentChild)
    {
        if(currentChild == null)
        {
            currentChild = transform.GetChild(0);
            return currentChild;
        }
        if(currentChild.GetSiblingIndex() < transform.childCount)
        {
            transform.GetChild(currentChild.GetSiblingIndex() + 1);
        }else
        {
            transform.GetChild(0);
        }
        return null;
    }
}