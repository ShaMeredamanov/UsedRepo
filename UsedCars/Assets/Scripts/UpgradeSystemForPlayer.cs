
using UnityEngine;

public class UpgradeSystemForPlayer : MonoBehaviour {
    [SerializeField] private GameObject _playerButton;
    [SerializeField] private GameObject _firtsPower;
    [SerializeField] private GameObject _secondPower;
    [SerializeField] private GameObject _thirdPower;
    [SerializeField] private GameObject _forthPower;
    [SerializeField] private GameObject _playerDisableParent;

    [SerializeField] private PlayerDjoystick _playerDjoystick;

    [SerializeField] private UiCanvas _UiCanvas;
    private int _playerScore = 2000;
    private int playerindex;

    public void PlayerINdex() {
        switch (playerindex) {
            case 0:
                playerindex++;
                _UiCanvas.DecrementScore(_playerScore);
                _playerDjoystick.UpgardePLayerSpeed(2f);

                _firtsPower.SetActive(true);
                break;
            case 1:
                playerindex++;
                _UiCanvas.DecrementScore(_playerScore);
                _playerDjoystick.UpgardePLayerSpeed(2f);
                _secondPower.SetActive(true);
                break;
            case 2:
                _UiCanvas.DecrementScore(_playerScore);
                playerindex++;
                _playerDjoystick.UpgardePLayerSpeed(3f);
                _thirdPower.SetActive(true);
                break;
            default:
                _UiCanvas.DecrementScore(_playerScore);
                playerindex++;
                _playerDisableParent.SetActive(false);
                _playerDjoystick.UpgardePLayerSpeed(3f);
                _forthPower.SetActive(true);
                _playerButton.SetActive(false);
                break;

        }
    }

}