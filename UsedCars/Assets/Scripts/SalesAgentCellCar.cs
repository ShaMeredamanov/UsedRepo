
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalesAgentCellCar : MonoBehaviour {
    [SerializeField] private CarsParentPoint carsParentpoint;
    [SerializeField] private List<Transform> _childTransform;
    [SerializeField] private List<Image> _images;
    [SerializeField] private List<GameObject> _imageParentObjects;
    private void Start() {
        foreach (var child in _imageParentObjects) {
         //   child.gameObject.SetActive(false);  
        }
    }
    private void OnDrawGizmos() {
            foreach (Transform t in transform) {
                Gizmos.color = Color.black;
                Gizmos.DrawWireSphere(t.position, 10f);
            }
            Gizmos.color = Color.red;
            for (int i = 0; i < transform.childCount - 1; i++) {
                Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
            }
        }
    public Transform GetMextWayPoint(Transform childTransform) {
        childTransform = _childTransform[carsParentpoint.CurrentIndex()];
        return childTransform;
    }
    public Image GetNewImage(Image image) {
        image = _images[carsParentpoint.CurrentIndex()];
        image.gameObject.SetActive(true);
        return image;
    }
    public GameObject GetNewGameObject(GameObject gameObject) {
        gameObject = _imageParentObjects[carsParentpoint.CurrentIndex()];
        gameObject.SetActive(true);
        return gameObject;
    }
   
    public void AddCarPath(Transform transform) {
        _childTransform.Add(transform);
    }
    public void AddImage(Image image, GameObject imageParent) {
        _images.Add(image);
        _imageParentObjects.Add(imageParent);
    }
}