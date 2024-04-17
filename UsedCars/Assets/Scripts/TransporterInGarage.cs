using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterInGarage : MonoBehaviour , ITransportParent
{
    [SerializeField] private Transform topPoint;
    private ITransportParent conveirObject;
    private CarObject carObject;
  
    public Transform GetTransfroms()
    {
        return topPoint;
    }
    /// <summary>
    ///Read only  
    /// </summary>
    /// <returns></returns>
    public Transform GetTopPoint()
    {
        return topPoint;
    }
    public ITransportParent GetChildCar()
    {

       
        return conveirObject;
    }
    public void SetCarObject(ITransportParent conveirObjects){
        conveirObject = conveirObjects;
    }
    public void ClearCarObject()
    {
        carObject = null;
    }
    public bool HasCarObject()
    {
        return carObject != null;
    }
    public CarObject GetCarObject()
    {
        carObject = topPoint.GetChild(0).GetComponent<CarObject>();
        carObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
        return carObject;
    }

    public GameObject ActivatedObject() {
        GameObject gameobject = gameObject;
        gameobject.SetActive(true);
        return gameobject;
    }
}
