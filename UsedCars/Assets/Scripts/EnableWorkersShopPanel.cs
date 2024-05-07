using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWorkersShopPanel : MonoBehaviour {
    [SerializeField] private GameObject _shopWorkers;
    [SerializeField] private GameObject _shopWorkersButton;
    [SerializeField] private GameObject _shopCarsPanel;
    [SerializeField] private GameObject _carsButton;
    public void OnTriggerClick() {
        _shopWorkers.SetActive(true);
        _carsButton.SetActive(true);
    }

   public void OnClickClosButton() {
        _shopWorkers.gameObject.SetActive(false);
        _carsButton.SetActive(false);
        _shopCarsPanel.SetActive(false);
        _shopWorkersButton.SetActive(false);
    }
}
