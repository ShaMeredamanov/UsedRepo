using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstReceptionChooseCar : MonoBehaviour, IReceptionParent {
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private List<Transform> _clients;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private SecondReceptionSignContract _secondReceptionSignContract;
    [SerializeField] private FirstRepiarShop _firstRepiarShop;
    [SerializeField] private WaitingQueueParent _waitingQueueParent;
    [SerializeField] private Image _image;
    private FemaleCashier _femaleCashier;
    private PlayerDjoystick _playerDjoystick;
    private Transform currentBuyer;
    private PeopleStateMachine _peopleStateMachine;
    private float fillAmount;
    private bool getCorountineOnce;
    private void Start() {
        _image.fillAmount = 0;
        fillAmount = 0;
    }
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
                _boxCollider.enabled = false;
            }
        }
    }
    private void OnTriggerStay(Collider other) {
        if (HasPlayer()) {
            if (_peopleStateMachine.CheckStateIsStateInsideRoom()) {
                if (!getCorountineOnce) {
                    getCorountineOnce = true;
                    if (_femaleCashier == null) {
                        StartCoroutine(CalculateTime());
                    }
                }
            }
        }
        if (other.TryGetComponent<FemaleCashier>(out var female)) {
            if (_peopleStateMachine.CheckStateIsStateInsideRoom()) {
                if (!getCorountineOnce) {
                    _femaleCashier = female;
                    getCorountineOnce = true;
                    StartCoroutine(CalculateTime());
                }
            } else {
                StopAllCoroutines();
                fillAmount = 0;
                _image.fillAmount = 0;
                getCorountineOnce = false;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            ClearPlayer();
            if (_femaleCashier == null) {
                StopAllCoroutines();
                fillAmount = 0;
                _image.fillAmount = 0;
                getCorountineOnce = false;
            }
        }
    }
    private int IndexBuyer() {
        int currentIndex = _clients.IndexOf(currentBuyer);
        _clients.RemoveAt(currentIndex);
        return currentIndex;
    }
    public void EnableCapsuleColliderComponent() {
        _boxCollider.enabled = true;

    }
    private IEnumerator CalculateTime() {
        while (_playerDjoystick != null) {
            if (fillAmount < 1f) {
                if (_waitingQueueParent.ChildrensTransforms.Count - 1 > _waitingQueueParent.Index) {
                    Debug.Log("in cororutine");
                    fillAmount += (float)0.0125f;
                    _image.fillAmount = (float)fillAmount;
                    yield return new WaitForSeconds(0.05f);
                } else {
                    yield return null;
                }
            } else {
                yield return null;
            }
        }
        while (_femaleCashier != null) {
            if (fillAmount < 1f) {
                if (_waitingQueueParent.ChildrensTransforms.Count - 1 > _waitingQueueParent.Index) {
                    fillAmount += (float)0.0125f;
                    _image.fillAmount = (float)fillAmount;
                    yield return new WaitForSeconds(0.05f);
                } else {
                    yield return null;
                }
            } else {
                yield return null;
            }
        }
    }
    public FirstRepiarShop FirstRepiarShop => _firstRepiarShop;
    public FemaleCashier FemaleCashier => _femaleCashier;

}
