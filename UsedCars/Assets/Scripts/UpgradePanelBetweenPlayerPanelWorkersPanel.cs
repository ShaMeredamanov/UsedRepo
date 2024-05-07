using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelBetweenPlayerPanelWorkersPanel : MonoBehaviour {
    [Header("Player panel")]
    [SerializeField] private GameObject _playerPanel;
    [SerializeField] private GameObject _playerButton;
    [Header("Workers Panel")]
    [SerializeField] private GameObject _workersPanel;
    [SerializeField] private GameObject _workersButton;

    public void PLayerPanel() {
        _playerPanel.SetActive(true);
        _playerButton.SetActive(false);
        _workersPanel.SetActive(false);
        _workersButton.SetActive(true);
    }

    public void WorkersPanel() {
        _playerButton?.SetActive(true);
        _workersPanel.SetActive(true);
        _playerPanel.SetActive(false);
        _workersButton.SetActive(false);
    }
}