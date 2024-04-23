
using System.Collections.Generic;
using UnityEngine;

public class SecondReceptionSignContract : MonoBehaviour {
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private FirstReceptionChooseCar _firstChooseCar;
    [SerializeField] private SecondRepairShop _secondRepairShop;
    [SerializeField] private List<Transform> buyers;
    [SerializeField] private UiCanvas _uiCanvas;
    [SerializeField] private WaitingQueueParent _waitingQueueParent;
    private PlayerDjoystick _playerDjoystick;
    private Transform _currentClient;
    private EskalatorInteractionStateMachine _interactionStateMachine;
    private float timer = 5f;
    private float timerMax = 5f;
    private void Start() {
        buyers = new List<Transform>();
    }
    public bool CanGetClient() {
        return buyers[0] == null;
    }
    public void ClearClient() {
        if (buyers.Count > 0) {
            buyers.RemoveAt(0);
            _waitingQueueParent.DecrementIndex();
            _uiCanvas.GEtMoney();
            _currentClient = null;
            _secondRepairShop.RemoveFromList();
            for (int i = 0; i < buyers.Count; i++) {
                buyers[i].GetComponent<PeopleStateMachine>().ChangeToGetStateAgaingToTrue();
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
            if (_secondRepairShop.EskalatorInteractionStateMachineList.Count >= 1) {
                if (timer <= 0) {
                    timer = timerMax;
                    buyers[0].GetComponent<PeopleStateMachine>().ChangeState();
                    ClearClient();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            ClearPlayer();
        }
    }
}
