using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstReceptionChooseCar : MonoBehaviour, IReceptionParent {
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private List<Transform> _clients;
    [SerializeField] private CapsuleCollider _capsula;
    [SerializeField] private SecondReceptionSignContract _secondReceptionSignContract;
    [SerializeField] private FirstRepiarShop _firstRepiarShop;
    private PlayerDjoystick _playerDjoystick;
    private Transform currentBuyer;
    private PeopleStateMachine _peopleStateMachine;
    public bool CanGetClient() {
        return currentBuyer == null;
    }
    public void ClearClient() {
      IndexBuyer();
    }
    public void GetClient(Transform current) {
        if (_clients.Count > 0) {
            currentBuyer = _clients[Random.Range(0, _clients.Count - 1)];
            _peopleStateMachine = currentBuyer.GetComponent<PeopleStateMachine>();
            _peopleStateMachine.ChooseCar(this);

        } else {
            Debug.LogError("there is no clients");
        }
    }
    public Transform GetClientTransform() {
        return currentBuyer;
    }
    public bool HasPlayer() {
        return _playerDjoystick != null;
    }
    public bool ClearPlayer() {
        return _playerDjoystick = null;
    }
    private void Awake() {
        // there is current buyer do not do something you need change in ireception parent this paremtr default
        GetClient(currentBuyer);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = playerDjoystick;
            if (!_peopleStateMachine.CheckStateIsStateInsideRoom()) {
                _capsula.enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            ClearPlayer();
        }
    }
    private int IndexBuyer() {
        int currentIndex = _clients.IndexOf(currentBuyer);
        _clients.RemoveAt(currentIndex);
        return currentIndex;
    }
    public void EnableCapsuleColliderComponent() {
        _capsula.enabled = true;
    }
    public FirstRepiarShop FirstRepiarShop => _firstRepiarShop;

}
