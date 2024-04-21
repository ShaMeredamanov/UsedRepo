using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class ChangeScale : MonoBehaviour {
    /// <summary>
    /// Onarnmaly bag bar ulalayp kicelip durya
    /// </summary>
    [SerializeField] private RectTransform _shadowRecTransform;
    private Vector3 shadowStartScale;
    private Vector3 shadowEndScale;
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {

            StartCoroutine(AddSmoothScale());
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<PlayerDjoystick>(out var playerDjoystick)) {
            StopCoroutine(AddSmoothScale());
            StartCoroutine(RemoveWithSmoothnes());
        }
    }
    private IEnumerator AddSmoothScale() {
        if (shadowStartScale == Vector3.zero) {
            shadowStartScale = _shadowRecTransform.localScale;
            shadowEndScale = _shadowRecTransform.localScale * 1.2f;
        }
        float smoothnes = 0.02f;
        while (_shadowRecTransform.localScale.x <= shadowEndScale.x) {
            _shadowRecTransform.localScale += shadowStartScale * smoothnes;
            yield return new WaitForSecondsRealtime(0.035f);
        }
        yield return null;
    }
    private IEnumerator RemoveWithSmoothnes() {
        float smoothnes = 0.02f;
        while (_shadowRecTransform.localScale.x >= shadowStartScale.x) {
            _shadowRecTransform.localScale -= shadowStartScale * smoothnes;
            yield return new WaitForSecondsRealtime(0.035f);
        }
        shadowStartScale = Vector3.zero;
        yield return null;
    }
}
