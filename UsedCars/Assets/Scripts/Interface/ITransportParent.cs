using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransportParent
{
    public Transform GetTransfroms();
    public bool HasCarObject();
    public void SetCarObject(ITransportParent carObject);
    public void ClearCarObject();
}
