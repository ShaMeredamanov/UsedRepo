using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour, ITransportParent {
    [SerializeField] private List<GameObject> _carObjects;
    [SerializeField] private Transform _topPoint;
    private EskalatorInteractionStateMachine _eskalatorInteractionStateMachine;
    private ITransportParent _carObject;
    private GameObject carTransForm;
    private void Start() { 
    
        _eskalatorInteractionStateMachine = GetComponent<EskalatorInteractionStateMachine>();   
    }
    public Transform GetTransfroms() {
        Debug.Log("i am transporter");
        return _topPoint;
    }
    /// <summary>
    /// Get child
    /// </summary>
    public ITransportParent GetChildCar() {
        _carObject = _topPoint.GetChild(0).GetComponent<ITransportParent>();
        return _carObject;
    }

    public bool HasCarObject() {
        return _carObject != null;
    }

    public void SetCarObject(ITransportParent carObject) {
        _carObject = carObject;
    }

    public void ClearCarObject() {
        carTransForm = null;
    }
    public CarObject CreateCarObject() {
        var randomCar = Random.Range(0, _carObjects.Count - 1);
        carTransForm = Instantiate(_carObjects[randomCar], _topPoint.position, _topPoint.transform.rotation, _topPoint);
        CarObject carObject = carTransForm.GetComponent<CarObject>();
        carTransForm.transform.localPosition = Vector3.zero;
        return carObject;
    }
    public CarObject GetCarObject() {
        CarObject carObject = carTransForm.GetComponent<CarObject>();
        return carObject;
    }

    public GameObject ActivatedObject() {
        GameObject gmObject = gameObject;
        gmObject.SetActive(true);
        return gmObject;
    }
    public GameObject CarTransform => carTransForm;
    public EskalatorInteractionStateMachine EskalatorInteractionStateMachine => _eskalatorInteractionStateMachine;
}
