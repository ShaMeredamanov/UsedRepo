using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBetweenCarsWokers : MonoBehaviour {
    [SerializeField] private GameObject _workersButton;
    [SerializeField] private GameObject _workersPanel;

    [SerializeField] private GameObject _carsButton;
    [SerializeField] private GameObject _carsPanel;

    public void EnableWorkersPanel() {
        _workersPanel.SetActive(true);
        _carsButton.SetActive(true);
        _carsPanel.SetActive(false);
        _workersButton.SetActive(false);
    }
    public void EnableCarsPanel() {
        _carsPanel.SetActive(true);
        _carsButton.SetActive(false);
        _workersPanel.SetActive(false);
        _workersButton.SetActive(true);
    }
}