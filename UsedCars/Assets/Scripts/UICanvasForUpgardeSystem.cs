using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasForUpgardeSystem : MonoBehaviour {
    [Header("Disable buttons")]
    [SerializeField] private GameObject _firstReceptionistDisableParent;
    [SerializeField] private GameObject _secondMehanicDisableParent;
    [SerializeField] private GameObject _thirdCarCleanerDisableParent;
    [SerializeField] private GameObject _fourthCashierDisableParent;
    [SerializeField] private GameObject _fivethConsultanatDisableParent;
    [SerializeField] private GameObject _playerDsiableParent;


    [SerializeField] private ShopPanelButtonGetWorkers getWorkers;
    private UiCanvas _uiCanvas;

    private void Start() {
        _uiCanvas = GetComponent<UiCanvas>();
    }
    private void Update() {
        if (_uiCanvas.Score >= 2000) {
            if (getWorkers.RecepstionitsBuyed) {
                _firstReceptionistDisableParent.SetActive(false);
            }
            if (getWorkers.SecondMehanicBuyed) {
                _secondMehanicDisableParent.SetActive(false);
            }
            if (getWorkers.ThirdCarCleanerBuyed) {
                _thirdCarCleanerDisableParent.SetActive(false);
            }
            if (getWorkers.FourthCashierBuyed) {
                _fourthCashierDisableParent.SetActive(false);
            }
            if (getWorkers.FivethSalesAgentBuyed) {
                _fivethConsultanatDisableParent.SetActive(false);
            }
            _playerDsiableParent.SetActive(false);
        } else {

            _firstReceptionistDisableParent.SetActive(true);
            _playerDsiableParent.SetActive(true);
            _secondMehanicDisableParent.SetActive(true);
            _thirdCarCleanerDisableParent.SetActive(true);
            _fourthCashierDisableParent.SetActive(true);
            _fivethConsultanatDisableParent.SetActive(true);

        }
    }
}
