using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReparingWaypoint{

    public class ReapirCarWayPoints : MonoBehaviour
    {
        private bool hasCarObject;
        private void OnDrawGizmos()
        {
            foreach (Transform t in transform)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(t.position, 1f);
            }
            Gizmos.color = Color.red;
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
            }
        }
        public Transform GetNextWayPoint(Transform currentWayPoint)
        {
            hasCarObject = true;
            if (currentWayPoint == null)
            {

                return transform.GetChild(0);
            }
            if (currentWayPoint.GetSiblingIndex() < transform.childCount - 1)
            {
                hasCarObject = false;
                return transform.GetChild(currentWayPoint.GetSiblingIndex() + 1);
            }
            else
            {
                return transform.GetChild(0);
            }
        }
        public Transform GetThisComponentTransfrom(Transform currentTransfrom)
        {
            currentTransfrom = transform;
            return currentTransfrom;
        }
        /// <summary>
        /// Read Only properties
        /// </summary>
        /// <returns></returns>
        public bool HasCarObject()
        {
            return hasCarObject;
        }
    }
}