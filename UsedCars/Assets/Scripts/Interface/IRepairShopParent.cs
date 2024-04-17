using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRepairShopParent {

    public void GetCar(Transform transform);
    public bool HasCar();
    public void ClearCar();

}
