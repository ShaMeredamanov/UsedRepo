
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondReceptionSignContract : MonoBehaviour {
    [SerializeField] private SecondRepairShop _secondRepairShop;
    [SerializeField] private List<Transform> buyers;
    [SerializeField] private UiCanvas _uiCanvas;
    [SerializeField] private WaitingQueueParent _waitingQueueParent;
    [SerializeField] private Image _image;
    [SerializeField] private SecondWashShopStateMachine _secondWashShopStateMachine;
    private float fillAmount;
    private bool getCorountineOnce;
    private PlayerDjoystick _playerDjoystick;
    private Transform _currentClient;
    private EskalatorInteractionStateMachine _interactionStateMachine;
    private float timer = 5f;
    private float timerMax = 5f;
    private void Start() {
        buyers = new List<Transform>();
        fillAmount = 0;
        _image.fillAmount = 0;
    }
 
    public void ClearClient() {
        if (buyers.Count > 0) {
            buyers.RemoveAt(0);
        //    _waitingQueueParent.DecrementIndex();
         //   _uiCanvas.GEtMoney();
            _currentClient = null;
            //_secondRepairShop.RemoveFromList();
       //     _secondWashShopStateMachine.RemoveFromList();
            for (int i = 0; i < buyers.Count; i++) {
             //   buyers[i].GetComponent<PeopleStateMachine>().ChangeToGetStateAgaingToTrue();
            }
        }
    }
    public void GetClient(Transform currentCleint) {
        _currentClient = currentCleint;
        buyers.Add(_currentClient);
    }
    public void ClearPlayer() {
        _playerDjoystick = null;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = playerDjoystick;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (_playerDjoystick != null) {

            timer -= Time.deltaTime;
            if (_secondWashShopStateMachine.EskalatorInteractionStateMachinesList.Count >= 1) {
                if (!getCorountineOnce) {
                    StartCoroutine(CalculateTime());
                    getCorountineOnce = true;
                }
                if (timer <= 0) {
                    timer = timerMax;
              //      buyers[0].GetComponent<PeopleStateMachine>().ChangeStateToBuyCar();
                    ClearClient();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            ClearPlayer();
            fillAmount = 0;
            _image.fillAmount = 0;
            StopAllCoroutines();
            getCorountineOnce = false;
        }
    }
    private IEnumerator CalculateTime() {
        while (_playerDjoystick != null) {
            if (fillAmount < 1f) {
                fillAmount += (float)0.0125f;
                _image.fillAmount = (float)fillAmount;
                yield return new WaitForSeconds(0.05f);
            } else {
                yield return null;
            }
        }
    }
}
