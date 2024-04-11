using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParentConveinerWayPoint
{
    public class ParentConveinerWayPoint : MonoBehaviour
    {
        private bool hasCar;
        private int index;
        private List<Transform> childTransform;
        private void Start()
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                childTransform.Add(transform.GetChild(i));
            }
        }
        public Transform GetChildTransform(Transform currentChild)
        {
            foreach (Transform childTransform in childTransform)
            {
                var getChildTransformComponent = childTransform.GetComponent<ReparingWaypoint.ReapirCarWayPoints>();
                if (getChildTransformComponent.HasCarObject())
                {
                    index++;
                }
                else
                {
                    if (index > 0)
                    {
                        index--;
                    }
                }
            }
            currentChild = transform.GetChild(index);
            return currentChild;
        }
    }
}