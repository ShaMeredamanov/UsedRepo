using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObject : MonoBehaviour
{
    private ITransportParent _transporter;
   public void SetUsedCars(Transform transporter)
    {
        _transporter = transporter.GetComponent<ITransportParent>();
        _transporter.GetTransfrom();
        transform.parent = transporter;
        transform.localPosition = Vector3.zero;
    }
}
