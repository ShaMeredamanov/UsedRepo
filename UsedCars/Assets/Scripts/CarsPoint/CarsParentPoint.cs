
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
    private int currentIndex;
    public Transform GetCurrentCarsWayPoint(Transform currentTransfrom) {
         currentIndex = Random.Range(0, _allChild.Count);
      
        currentTransfrom = _allChild[currentIndex];
        return currentTransfrom;
    }
    public void AddCarPath(Transform carPath) {
        _allChild.Add(carPath);
    }
    public int GetMoneyWithTransform(Transform currentRansform) {
        var index = _allChild.IndexOf(currentRansform);
        if (index == 0) {
            return 1200;
        } else if (index == 1) {
            return 2000;
        } else if (index == 2) {
            return 2400;
        } else if (index == 3) {
            return 3000;
        } else if (index == 4) {
            return 4000;
        } else if (index == 5) {
            return 3600;
        } else {
            return 0;
        }
    }
    public Transform GetPointForSalesAgent(Transform currentPoint) {
        currentPoint = _allChild[currentIndex];
        return currentPoint;
    }

    public int CurrentIndex() {
        return currentIndex;
    }

}
