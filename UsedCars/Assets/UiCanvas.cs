using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCanvas : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI _score;
    private int score;
    private void Start() {
        score = 0;
        _score.text = " " + score;

    }
    public void GEtMoney() {
        score += 5;
        _score.text = " " + score;
    }
}
