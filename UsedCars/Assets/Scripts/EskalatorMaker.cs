using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorMaker : MonoBehaviour
{
    [SerializeField] private GameObject eskalator;
    [SerializeField] private Transform spawnPoint;
    private void Start()
    {
        SetEskalatorObject();
    }
    public void SetEskalatorObject()
    {
        GameObject eskaltorObject = Instantiate(eskalator, spawnPoint.position, spawnPoint.rotation);
    }
}
