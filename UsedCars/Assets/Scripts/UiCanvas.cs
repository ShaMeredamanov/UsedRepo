
using TMPro;
using UnityEngine;

public class UiCanvas : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI _score;

    [Header("Cars")]
    [SerializeField] private GameObject _secondBlackPanterDisableButton;
    [SerializeField] private GameObject _thirdGrayGhostDisableButton;
    [SerializeField] private GameObject _fourthPoyalAzureDisbaleButton;
    [SerializeField] private GameObject _fivethOrangeFureDisbaleButton;
    [SerializeField] private GameObject _sixthBlackOrangeFureDisbaleButton;

    [Header("Workers disable buttons")]
    [SerializeField] private GameObject _firtsReceptionist;
    [SerializeField] private GameObject _secondMehanic;
    [SerializeField] private GameObject _thirdCarCleaner;
    [SerializeField] private GameObject _fourthCashier;
    [SerializeField] private GameObject _fivethSalesAgent;
    private int _scoreNumber;

    private void Start() {
        _scoreNumber = 100000;
        _score.text = " " + _scoreNumber;
    }


    private void Update() {
        if (_scoreNumber >= 3000) {
            _secondBlackPanterDisableButton.SetActive(false);
            _firtsReceptionist.SetActive(false);
        } else {
            _secondBlackPanterDisableButton.SetActive(true);
            _firtsReceptionist.SetActive(true);
        }
       
        if (_scoreNumber >= 6000) {
            _secondMehanic.SetActive(false);
            _thirdGrayGhostDisableButton.SetActive(false);
        } else {
            _thirdGrayGhostDisableButton.SetActive(true);
            _secondMehanic.SetActive(true);
        }
        if (_scoreNumber >= 6000) {
            _thirdCarCleaner.SetActive(false);
        } else {
           
            _thirdCarCleaner.SetActive(true);
        }
        if (_scoreNumber >= 12000) {
            _fourthCashier.SetActive(false);
            _fourthPoyalAzureDisbaleButton.SetActive(false);
        } else {
            _fourthCashier.SetActive(true);
            _fourthPoyalAzureDisbaleButton.SetActive(true);
        }
        if (_scoreNumber >= 16000) {
            _fivethSalesAgent.SetActive(false);
            _fivethOrangeFureDisbaleButton.SetActive(false);
        } else {
            _fivethOrangeFureDisbaleButton.SetActive(true);
            _fivethSalesAgent.SetActive(true);
        }
        if (_scoreNumber >= 20000) {
            _sixthBlackOrangeFureDisbaleButton.SetActive(false);
        } else {
            _sixthBlackOrangeFureDisbaleButton.SetActive(true);
        }
        //if (_scoreNumber <= 7500) {
        //    _secondBlackPanterDisableButton.SetActive(true);
        //    _thirdGrayGhostDisableButton.SetActive(true);
        //    _fourthPoyalAzureDisbaleButton.SetActive(true);
        //    _fivethOrangeFureDisbaleButton.SetActive(true);
        //    _sixthBlackOrangeFureDisbaleButton.SetActive(true);
        //}
    }

    public void GEtMoney(int score) {

        _scoreNumber += score;
        _score.text = " " + _scoreNumber;
    }
    public void DecrementScore(int score) {
        _scoreNumber -= score;
        _score.text = " " + _scoreNumber;
    }
    
    /// <summary>
    ///Read Only properties 
    /// </summary>
    public int Score => _scoreNumber;
}
