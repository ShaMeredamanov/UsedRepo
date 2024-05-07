using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SalesAgentInteractionStateMachine;

public class UpgradeSystemWorkers : MonoBehaviour {
    [Header("Receptionist Upgrade")]
    [SerializeField] private GameObject _receptionistButton;
    [SerializeField] private GameObject _receptionistPowerFirts;
    [SerializeField] private GameObject _receptionistPowerSecond;
    [SerializeField] private GameObject _receptionistPowerThird;
    [SerializeField] private GameObject _receptionistPowerFourth;
    [SerializeField] private GameObject _receptionparentDisableButton;
    private int _receptionistScore = 2000;
    [Header("Mehanic Upgrade")]
    [SerializeField] private GameObject _mehanicButton;
    [SerializeField] private GameObject _mehanicPowerFirts;
    [SerializeField] private GameObject _mehanicPowerSecond;
    [SerializeField] private GameObject _mehanicPowerThird;
    [SerializeField] private GameObject _mehanicPowerFourth;
    [SerializeField] private GameObject _mehanicparentDisableButton;
    [Header("CarClener Upgrade")]
    [SerializeField] private GameObject _carCleanerButton;
    [SerializeField] private GameObject _carCleanerFirts;
    [SerializeField] private GameObject _carCleanerSecond;
    [SerializeField] private GameObject _carCleanerThird;
    [SerializeField] private GameObject _carCleanerFourth;
    [SerializeField] private GameObject _carCleanerparentDisableButton;
    [Header("Cashier Upgrade")]
    [SerializeField] private GameObject _cashierButton;
    [SerializeField] private GameObject _cashierFirts;
    [SerializeField] private GameObject _cashierSecond;
    [SerializeField] private GameObject _cashierThird;
    [SerializeField] private GameObject _cashierFourth;
    [SerializeField] private GameObject _cashierParentDisableButton;
    [Header("Sales Agent Upgrade")]
    [SerializeField] private GameObject _salesAgentButton;
    [SerializeField] private GameObject _salesAgentFirts;
    [SerializeField] private GameObject _salesAgentSecond;
    [SerializeField] private GameObject _salesAgentThird;
    [SerializeField] private GameObject _salesAgentFourth;
    [SerializeField] private GameObject _salesAgentParentDisableButton;
    [Header("State machines")]
    [SerializeField] private ReceptionChooseCarStateMachine _receptionChooseCarStateMachine;
    [SerializeField] private SignContractInteractionStateMachine _signContractInteractionStateMachine;
    [SerializeField] private FirstRepairShopInteractionStateMachine _firstRepairShopInteractionStateMachine;
    [SerializeField] private SecondWashShopStateMachine _secondWashShopStateMachine;
    [SerializeField] private SalesAgentInteractionStateMachine _salesAgentInteractionStateMachine;

    [SerializeField] private UiCanvas uiCanvas;
    private int indexReceptionist;
    private int indexMehanic;
    private int indexCarCleaner;
    private int indexCashier;
    private int indexSalesAgent;

    public void ReceptionistPower() {
        switch (indexReceptionist) {
            case 0:
                indexReceptionist++;
                uiCanvas.DecrementScore(_receptionistScore);
                _receptionistPowerFirts.SetActive(true);
                _receptionChooseCarStateMachine.ChangeUpgradePriceAndTimer(1 );
                break;
            case 1:
                indexReceptionist++;
                uiCanvas.DecrementScore(_receptionistScore);
                _receptionChooseCarStateMachine.ChangeUpgradePriceAndTimer(1);
                _receptionistPowerSecond.SetActive(true);
                break;
            case 2:
                indexReceptionist++;
                uiCanvas.DecrementScore(_receptionistScore);
                _receptionChooseCarStateMachine.ChangeUpgradePriceAndTimer(1);
                _receptionistPowerThird.SetActive(true);
                break;
            default:
                _receptionistPowerFourth.SetActive(true);
                uiCanvas.DecrementScore(_receptionistScore);
                _receptionChooseCarStateMachine.ChangeUpgradePriceAndTimer(1);
                _receptionistButton.SetActive(false);
                _receptionparentDisableButton.SetActive(false);
                break;
        }
    }
    public void MehanicPower() {
        switch (indexMehanic) {
            case 0:
                indexMehanic++;
                uiCanvas.DecrementScore(_receptionistScore);
                _firstRepairShopInteractionStateMachine.ChangeTimerAndUpgrade(1f);
                _mehanicPowerFirts.SetActive(true);
                break;
            case 1:
                indexMehanic++;
                uiCanvas.DecrementScore(_receptionistScore);
                _firstRepairShopInteractionStateMachine.ChangeTimerAndUpgrade(1f);
                _mehanicPowerSecond.SetActive(true);
                break;
            case 2:
                indexMehanic++;
                uiCanvas.DecrementScore(_receptionistScore);
                _firstRepairShopInteractionStateMachine.ChangeTimerAndUpgrade(1f);
                _mehanicPowerThird.SetActive(true);
                break;
            default:
                uiCanvas.DecrementScore(_receptionistScore);
                _mehanicPowerFourth.SetActive(true);
                _firstRepairShopInteractionStateMachine.ChangeTimerAndUpgrade(1f);
                _mehanicButton.SetActive(false);
                _mehanicparentDisableButton.SetActive(false);
                break;
        }
    }  public void CarCleanerPower() {
        switch (indexCarCleaner) {
            case 0:
                _secondWashShopStateMachine.ChangeUpgradeAndTimer(1f);
                uiCanvas.DecrementScore(_receptionistScore);
                indexCarCleaner++;
                _carCleanerFirts.SetActive(true);
                break;
            case 1:
                uiCanvas.DecrementScore(_receptionistScore);
                _secondWashShopStateMachine.ChangeUpgradeAndTimer(1f);
                indexCarCleaner++;
                _carCleanerSecond.SetActive(true);
                break;
            case 2:
                _secondWashShopStateMachine.ChangeUpgradeAndTimer(1f);
                uiCanvas.DecrementScore(_receptionistScore);
                indexCarCleaner++;
                _carCleanerThird.SetActive(true);
                break;
            default:
                uiCanvas.DecrementScore(_receptionistScore);
                _secondWashShopStateMachine.ChangeUpgradeAndTimer(1f);
                _carCleanerFourth.SetActive(true);
                _carCleanerButton.SetActive(false);
                _carCleanerparentDisableButton.SetActive(false);
                break;
        }
    } public void CashierPower() {
        switch (indexCashier) {
            case 0:
                indexCashier++;
                uiCanvas.DecrementScore(_receptionistScore);
                _signContractInteractionStateMachine.ChnageUpgradeAndTimer(1f);
                _cashierFirts.SetActive(true);
                break;
            case 1:
                indexCashier++;
                uiCanvas.DecrementScore(_receptionistScore);
                _signContractInteractionStateMachine.ChnageUpgradeAndTimer(1f);
                _cashierSecond.SetActive(true);
                break;
            case 2:
                indexCashier++;
                uiCanvas.DecrementScore(_receptionistScore);
                _signContractInteractionStateMachine.ChnageUpgradeAndTimer(1f);
                _cashierThird.SetActive(true);
                break;
            default:
                uiCanvas.DecrementScore(_receptionistScore);
                _signContractInteractionStateMachine.ChnageUpgradeAndTimer(1f);
                _cashierFourth.SetActive(true);
                _cashierButton.SetActive(false);
                _cashierParentDisableButton.SetActive(false);
                break;
        }
    } public void SalesAgentPower() {
        switch (indexSalesAgent) {
            case 0:
                uiCanvas.DecrementScore(_receptionistScore);
                indexSalesAgent++;
                _salesAgentInteractionStateMachine.ChangeTimerAndUpgrade(0.5f);
                _salesAgentFirts.SetActive(true);
                break;
            case 1:
                indexSalesAgent++;
                uiCanvas.DecrementScore(_receptionistScore);
                _salesAgentInteractionStateMachine.ChangeTimerAndUpgrade(0.5f);
                _salesAgentSecond.SetActive(true);
                break;
            case 2:
                indexSalesAgent++;
                uiCanvas.DecrementScore(_receptionistScore);
                _salesAgentInteractionStateMachine.ChangeTimerAndUpgrade(0.5f);
                _salesAgentThird.SetActive(true);
                break;
            default:
                uiCanvas.DecrementScore(_receptionistScore);
                _salesAgentFourth.SetActive(true);
                _salesAgentInteractionStateMachine.ChangeTimerAndUpgrade(0.5f);
                _salesAgentButton.SetActive(false);
                _salesAgentParentDisableButton.SetActive(false);    
                break;
        }
    }


}