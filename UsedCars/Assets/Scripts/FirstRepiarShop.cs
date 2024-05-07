using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstRepiarShop : MonoBehaviour {
    //private const string REPAIR = "Repair";
    //[SerializeField] private Image _reoairImage;
    //[SerializeField] private CapsuleCollider _capsuleCollider;
    //[SerializeField] private Animator _reapairAnimator;
    //[SerializeField] private SecondRepairShop _secondRepairShop;
    //[SerializeField] private ParticleSystem _particleSystemRepair;
    //[SerializeField] private List<EskalatorInteractionStateMachine> _eskalatorInteractionList;
    //[SerializeField] private FirstCarRepairWayPointParent _firstCarRepairWayPointParent;
    //[SerializeField] private ThirdWayPointParentForQueue _thirdCarRepairWayPointParentForQueue;
    //private FemaleCashier _femaleCashier;
    //private EskalatorInteractionStateMachine stateMachineEskalator;
    //private PlayerDjoystick _playerDjoystick;
    //private float timer = 5f;
    //float fillAmount;
    //private bool getCoroutine;
    //private float timerMax = 5f;
    //private void Start() {
    //    _particleSystemRepair.Stop();
    //    fillAmount = 0;
    //    _reoairImage.fillAmount = 0;
    //    _eskalatorInteractionList = new List<EskalatorInteractionStateMachine>();
    //}
    //private void OnTriggerEnter(Collider other) {
    //    if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
    //        _playerDjoystick = playerDjoystick;
    //    }
    //}
    //private void OnTriggerStay(Collider other) {
    //    if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalator)) {
    //        if (_playerDjoystick != null) {
    //            timer -= Time.deltaTime;
    //            if (!getCoroutine) {
    //                getCoroutine = true;
    //                StartCoroutine(CalculateTime());
    //                _particleSystemRepair.Play();
    //            }
    //            _reapairAnimator.SetBool(REPAIR, true);
    //            if (timer < 0) {
    //                if (_secondRepairShop.EskalatorInteractionStateMachineList.Count < 1) {
    //                    _eskalatorInteractionList[0].GetComponent<EskalatorInteractionStateMachine>().ChangeState();
    //                    timer = timerMax;
    //                } else {
    //                    timer = timerMax;
    //                }
    //            }
    //        } else {
    //            _reapairAnimator.SetBool(REPAIR, false);
    //        }
    //    }
    //}
    //private void OnTriggerExit(Collider other) {
    //    if (other.TryGetComponent<EskalatorInteractionStateMachine>(out var eskalatorInteractionState)) {
    //        RemoveFromEsklatorList(eskalatorInteractionState);
    //        timer = timerMax;
    //        _reapairAnimator.SetBool(REPAIR, false);
    //        _particleSystemRepair.Stop();
    //    }
    //    if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
    //        _particleSystemRepair.Stop();
    //        getCoroutine = false;
    //        _playerDjoystick = null;
    //        timer = timerMax;
    //        fillAmount = 0;
    //        _reoairImage.fillAmount = 0;
    //        _reapairAnimator.SetBool(REPAIR, false);
    //        StopAllCoroutines();
    //    }
    //}
 
    //public void TransporterIngarage(TransporterInGarage transporterInGarage) {
    //    EskalatorInteractionStateMachine eskaltorStateMachine = transporterInGarage.StateMachineEskaltor();
    //    GetEsKalatorINteractionStateMachine(eskaltorStateMachine);
    //}
    //private void GetEsKalatorINteractionStateMachine(EskalatorInteractionStateMachine eskalatorInteractionStateMachine) {
    //    stateMachineEskalator = eskalatorInteractionStateMachine;
    //    _eskalatorInteractionList.Add(stateMachineEskalator);
    //}
    //public void RemoveFromEsklatorList(EskalatorInteractionStateMachine eskalatorInteractionStateMachine) {
    //    var index = _eskalatorInteractionList.IndexOf(eskalatorInteractionStateMachine);
    //    _eskalatorInteractionList.RemoveAt(index);
    //    _firstCarRepairWayPointParent.DecrementIndex();
    //    foreach (EskalatorInteractionStateMachine eskalatorInteractionState in _eskalatorInteractionList) {
    //        eskalatorInteractionState.GetWayPointAgainToTrue();
    //    }
    //}
    //private IEnumerator CalculateTime() {
    //    while (_playerDjoystick != null) {
    //        if (fillAmount < 1f) {
    //            fillAmount += (float)0.0125f;
    //            _reoairImage.fillAmount = (float)fillAmount;
    //            yield return new WaitForSeconds(0.05f);
    //        } else {
    //            yield return null;
    //        }
    //    }
    //    while (_femaleCashier != null) {
    //        if (fillAmount < 1f) {
    //            fillAmount += (float)0.0125f;
    //            _reoairImage.fillAmount = (float)fillAmount;
    //            yield return new WaitForSeconds(0.05f);
    //        } else {
    //            yield return null;
    //        }
    //    }
    //}
}

