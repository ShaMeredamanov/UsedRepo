using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour {
    //[SerializeField] private SalesAgentCellCar _salesCellCar;
    //private Image _image;
    //private GameObject _imageGameObejct;
    //private float fillAmount;
    //private float waitForSeconds;

    //private void Start() {
    //}
    //private void OnTriggerEnter(Collider other) {
    //    if (other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)) {
    //        waitForSeconds = 0.05f;
    //        _imageGameObejct = _salesCellCar.GetNewGameObject(_imageGameObejct);
    //        _image = _salesCellCar.GetNewImage(_image);
    //        _image.fillAmount = 0f;
    //        fillAmount = 0f;
    //        StartCoroutine(CalculateTime());
    //    }
    //}
    //private void OnTriggerExit(Collider other) {
    //    if (other.TryGetComponent<PeopleStateMachine>(out var peopleStateMachine)) {
    //        _imageGameObejct.SetActive(false);
    //        _image.gameObject.SetActive(false);
    //        StopCoroutine(CalculateTime());
    //    }
    //}
    //private IEnumerator CalculateTime() {
    //    while (true) {
    //        if (fillAmount < 1f) {
    //            Debug.Log("not work");
    //            fillAmount += (float)0.0130f;
    //            _image.fillAmount = (float)fillAmount;
    //            yield return new WaitForSeconds(waitForSeconds);
    //        } else {
    //            Debug.Log("stop coroutine");
    //            _imageGameObejct.SetActive(false);
    //            _image.gameObject.SetActive(false);
    //            StopCoroutine(CalculateTime());
    //            yield return null;
    //        }
    //    }
    //}
}