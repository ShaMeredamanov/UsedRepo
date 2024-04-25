using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondRepairShop : MonoBehaviour {
    private const string WASH = "Wash";
    [SerializeField] private Transporter _transporter;
    [SerializeField] private SecondReceptionSignContract _signContract;
    [SerializeField] private Animator _washAnimator;
    [SerializeField] private Image _washImage;
    [SerializeField] private List<EskalatorInteractionStateMachine> _eskalatorStateMachineList;
    [SerializeField] private ParticleSystem _washParticleSystem;
    [SerializeField] private ParticleSystem _washParticleSystemSecond;
    [SerializeField] private ThirdWayPointParentForQueue _thirdWayPointParentForQueue;
    private PlayerDjoystick _playerDjoystick;
    private float timer = 5f;
    private float timerMax = 5f;
    private float fillAmount;
    private bool getCourutine;
    private void Start() {
        _washImage.fillAmount = 0f;
        _washParticleSystem.Stop();
        _washParticleSystemSecond.Stop();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = playerDjoystick;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (_playerDjoystick != null) {
            if (_eskalatorStateMachineList.Count > 0) {
                if (_eskalatorStateMachineList[0] != null) {
                    if (!getCourutine) {
                        getCourutine = true;
                        StartCoroutine(CalculateTime());
                        _washParticleSystemSecond.Play();
                        _washParticleSystem.Play();
                        _washAnimator.SetBool(WASH, true);
                    }
                } else {
                    _washAnimator.SetBool(WASH, false);
                }
            }
            timer -= Time.deltaTime;
            if (timer < 0) {
                timer = timerMax;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            _playerDjoystick = null;
            timer = timerMax;
            _washAnimator.SetBool(WASH, false);
            fillAmount = 0;
            _washImage.fillAmount = 0;
            getCourutine = false;
            StopAllCoroutines();
            _washParticleSystem.Stop();
            _washParticleSystemSecond.Stop();
        }
        if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorStateMachine)) {
            timer = timerMax;
            _washAnimator.SetBool(WASH, false);
            _washParticleSystem.Stop();
            _washParticleSystemSecond.Stop();
        }
    }
    public void RemoveFromList() {
        _eskalatorStateMachineList.RemoveAt(0);
        _thirdWayPointParentForQueue.DecrementIndex();
        //foreach (EskalatorInteractionStateMachine eskalatorInteractionState in _eskalatorStateMachineList) {
        //    eskalatorInteractionState.GetWayPointAgainToTrue();
        //}
    }
    public void GetEskalatorToList(EskalatorInteractionStateMachine eskalatorInteractionState) {
        _eskalatorStateMachineList.Add(eskalatorInteractionState);
    }
    private IEnumerator CalculateTime() {
        while (_playerDjoystick != null) {
            if (fillAmount < 1f) {
                fillAmount += (float)0.0125f;
                _washImage.fillAmount = (float)fillAmount;
                yield return new WaitForSeconds(0.05f);
            } else {
                yield return null;
            }
        }
    }
    /// <summary>
    /// Read only properties
    /// </summary>
    /// <returns></returns>
    public PlayerDjoystick PlayerDjoystick => _playerDjoystick;
    public SecondReceptionSignContract SecondReceptionSignContract => _signContract;
    public List<EskalatorInteractionStateMachine> EskalatorInteractionStateMachineList => _eskalatorStateMachineList;
}
