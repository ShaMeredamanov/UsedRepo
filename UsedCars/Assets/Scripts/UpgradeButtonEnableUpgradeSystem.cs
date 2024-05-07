using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonEnableUpgradeSystem : MonoBehaviour
{
    [Header("Enable upgrade")]
    [SerializeField] private GameObject _upgradePlayerPanel;
    [SerializeField] private GameObject _upgradeButtonPlayer;


    [SerializeField] private GameObject _upgradeWorkers;
    [SerializeField] private GameObject _upgradeButtonWorkers;

    public void OnPointerClick() {
        _upgradePlayerPanel.SetActive(true);
        _upgradeButtonWorkers.SetActive(true);
    }
    public void DisableUpgrade() {
        _upgradePlayerPanel.SetActive(false);
        _upgradeButtonWorkers.SetActive(false);
        _upgradeWorkers.SetActive(false);
        _upgradeButtonPlayer.SetActive(false);


    }
}
