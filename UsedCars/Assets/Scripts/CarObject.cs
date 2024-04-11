using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObject : MonoBehaviour {
    [SerializeField] private GameObject crashCar;
    [SerializeField] private GameObject durtyCar;
    [SerializeField] private GameObject normalCar;

    private ITransportParent _transporter;
    public void SetUsedCars(ITransportParent transporter) {
        _transporter = transporter;
        transform.parent = _transporter.GetTransfroms();
        transform.localPosition = Vector3.zero;
    }
    public void ChangeDurtyCarToWHiteCar() {
        durtyCar.transform.localRotation = Quaternion.Euler(0f, 0, -90f);
        durtyCar.SetActive(true);
        crashCar.SetActive(false);
    }

    public void ChangeWHiteCarToNormalCar() {
        normalCar.transform.localRotation = Quaternion.Euler(0f, 0, -90f);
        durtyCar.SetActive(false);
        normalCar.SetActive(true);
    }
    /// <summary>
    /// Read only properties
    /// </summary>
}
