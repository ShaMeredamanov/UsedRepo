using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReceptionParent {
    public bool CanGetClient();
    public void GetClient(Transform currentCleint);
    public void ClearClient();
    public Transform GetClientTransform();  
    
}