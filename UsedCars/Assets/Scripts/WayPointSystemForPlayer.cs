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