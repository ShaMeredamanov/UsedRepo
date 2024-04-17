using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondReceptionSignContract : MonoBehaviour, IReceptionParent {

    private const string WORK = "Work";

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private FirstReceptionChooseCar _firstChooseCar;
    [SerializeField] private SecondRepairShop _secondRepairShop;
    [SerializeField] private List<Transform> buyers;
    [SerializeField] private UiCanvas _uiCanvas;
    private PlayerDjoystick _playerDjoystick;
    private PeopleStateMachine _peopleStateMachine;
    private Transform _currentClient;
    private EskalatorInteractionStateMachine _interactionStateMachine;  

    private void Start() {
        buyers = new List<Transform>();
    }
    public bool CanGetClient() {
        return _currentClient == null;
    }
    public void ClearClient() {
        if (buyers.Count > 0) {
            buyers.RemoveAt(0);
            _uiCanvas.GEtMoney();
            _currentClient = null;
            _playerAnimator.SetBool(WORK, false);
            _secondRepairShop.RemoveFromList();
        }
    }
    public void GetClient(Transform currentCleint) {
        _currentClient = currentCleint;
        _peopleStateMachine = _currentClient.GetComponent<PeopleStateMachine>();
        buyers.Add(_currentClient);


    }
    public bool HasPlayer() {
        return _playerDjoystick != null;
    }
    public void ClearPlayer() {
        _playerDjoystick = null;
    }

    public Transform GetClientTransform() {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _interactionStateMachine = _secondRepairShop.EskalatorInteractionStateMachineList[0];
            if (_interactionStateMachine != null) {
                _playerDjoystick = playerDjoystick;
                _playerAnimator.SetBool(WORK, true);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            ClearPlayer();
            _playerAnimator.SetBool(WORK, false);
        }
    }
    /// <summary>
    /// Read Only properties
    /// </summary>
    public SecondRepairShop SecondRepairShop => _secondRepairShop;
    public PeopleStateMachine PeopleStateMachine => _peopleStateMachine;
}
