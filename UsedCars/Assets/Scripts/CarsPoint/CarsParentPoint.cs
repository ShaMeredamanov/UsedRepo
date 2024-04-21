using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsParentPoint : MonoBehaviour {
    private void OnDrawGizmos() {
        foreach (Transform t in transform) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(t.position, 10f);
        }
        Gizmos.color = Color.red;
    }
    [SerializeField] private List<Transform> _allChild;
    public Transform GetCurrentCarsWayPoint(Transform currentTransfrom) {
        currentTransfrom = _allChild[Random.Range(0, _allChild.Count)];
        _allChild.Add(currentTransfrom);
        return currentTransfrom;
    }
}
