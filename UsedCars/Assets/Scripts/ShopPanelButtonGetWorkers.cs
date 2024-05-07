using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelButtonGetWorkers : MonoBehaviour {
    [Header("Mehenic")]
    [SerializeField] private GameObject _firstRepairShop;
    [SerializeField] private GameObject _buyButtonFirts;
    [SerializeField] private GameObject _alreadyBoughtRepir;
    [SerializeField] private GameObject _mahenicDisableParent;
    private bool _secondMehanicBuyed;
    [Header("Car cleaner")]
    [SerializeField] private GameObject _secnondWashShop;
    [SerializeField] private GameObject _buyButtonSecond;
    [SerializeField] private GameObject _alreadyBoughtWash;
    [SerializeField] private GameObject _carCleanerDisableParent;
    private bool _thirdCarCleanerBuyed;
    [Header("Recreptionist")]
    [SerializeField] private GameObject _receptionist;
    [SerializeField] private GameObject _buyButtonFirtsREceptionist;
    [SerializeField] private GameObject _alreadyBoughtReseptinits;
    [SerializeField] private GameObject _receptionistDisableParent;
    private bool _receptionistBuyed;

    [Header("Cashier")]
    [SerializeField] private GameObject _cashier;
    [SerializeField] private GameObject _alreadyBoughtSecondReseptinits;
    [SerializeField] private GameObject _buyButtonSecondREceptionist;
    [SerializeField] private GameObject _cashierDisableParent;
    private bool _fourthCashierBuyed;

    [Header("Consultant")]
    [SerializeField] private GameObject _consultant;
    [SerializeField] private GameObject _alreadyBoughtConsultant;
    [SerializeField] private GameObject _buyButtonConsultant;
    [SerializeField] private GameObject _consultantDisableParent;
    private bool _fivethSalesAgentBuyed;


    [Header("Canvas")]
    [SerializeField] private UiCanvas _uiCanvas;
    public void ActivateFirstRepairerShop() {
        _firstRepairShop.SetActive(true);
        _buyButtonFirts.SetActive(false);
        _alreadyBoughtRepir.SetActive(true);
        _mahenicDisableParent.SetActive(false);
        var score = 5000;
        _uiCanvas.DecrementScore(score);
        _secondMehanicBuyed = true;
    }
    public void ActivateSecondRepairerShop() {
        _secnondWashShop.SetActive(true);
        _buyButtonSecond.SetActive(false);
        _alreadyBoughtWash.SetActive(true);
        _carCleanerDisableParent.SetActive(false);
        var scoreCarCleaner = 7000;
        _uiCanvas.DecrementScore(scoreCarCleaner);
        _thirdCarCleanerBuyed = true;
    }
    public void Receptionist() {
        _receptionist.SetActive(true);
        _alreadyBoughtReseptinits.SetActive(true);
        _buyButtonSecondREceptionist.SetActive(false);
        _receptionistDisableParent.SetActive(false);
        var scoreReceptionist = 7200;
        _uiCanvas.DecrementScore(scoreReceptionist);
       _receptionistBuyed = true;
    }
    public void SecondReceptionist() {
        _cashier.SetActive(true);
        _buyButtonFirtsREceptionist.SetActive(false);
        _alreadyBoughtSecondReseptinits.SetActive(true);
        _cashierDisableParent.SetActive(false);
        var scoreCashier = 8000;
        _uiCanvas.DecrementScore(scoreCashier);
        _fourthCashierBuyed = true;
    }
   public void Consultant() {
        _consultant.SetActive(true);
        _alreadyBoughtConsultant.SetActive(true);
        _buyButtonConsultant.SetActive(false);
        _consultantDisableParent.SetActive(false);
        var scoreConsultant = 16000;
        _uiCanvas.DecrementScore (scoreConsultant);
       _fivethSalesAgentBuyed = true;
    }

    public bool RecepstionitsBuyed => _receptionistBuyed;
    public bool SecondMehanicBuyed => _secondMehanicBuyed;
    public bool ThirdCarCleanerBuyed => _thirdCarCleanerBuyed;
    public bool FourthCashierBuyed => _fourthCashierBuyed;
    public bool FivethSalesAgentBuyed => _fivethSalesAgentBuyed;
}
