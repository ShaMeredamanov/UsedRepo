using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterOnGarage : MonoBehaviour , ITransportParent
{
    public Transform GetTransfrom()
    {
        Debug.Log("i am transporter on garage");
        return transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
