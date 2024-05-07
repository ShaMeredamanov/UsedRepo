using UnityEngine;
using DG.Tweening;
public class DisableMoney : MonoBehaviour {
    private Vector3 endValue;
    private Vector3 startPosition;
    private PlayerDjoystick _playerDjoystick;
    private bool getFirstTime;
    private void Awake() {
        startPosition = transform.position; 
    }
    private void OnEnable() {
        transform.position = startPosition;
        endValue = transform.position + new Vector3(0, 30, 0);
        getFirstTime = false;
        }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var player)) {
            _playerDjoystick = player;
            if (!getFirstTime) {
                MoneyChangePosition();
                getFirstTime = true;
            }
        }
    }
    private void MoneyChangePosition() {
        transform.DOMove(endValue, 0.3f).OnComplete(() => {
            ChangePositionToPlayerPosition();
        });
    }
    private void ChangePositionToPlayerPosition() {
        transform.DOMove(_playerDjoystick.transform.position, 0.3f).OnComplete(() => {
            gameObject.SetActive(false);
        });
    }
}
