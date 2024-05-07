using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSettings : MonoBehaviour {
    [SerializeField] private GameObject _settingsObject;


    public void EnableSettingsObject() {
        _settingsObject.SetActive(true);
    }
    public void DisableSettingsObject() {
        _settingsObject.SetActive(false);
    }

}
