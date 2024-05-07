using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour {

    private float fadeSpeed;
    private float minAlpha;
    private float maxAlpha;
    private float delayBetweenFades;

    private Image image;
    private CanvasRenderer _canvasRenderer;

    private void Start() {

        _canvasRenderer = GetComponent<CanvasRenderer>();
        fadeSpeed = .5f;
        minAlpha = 0.0f;
        maxAlpha = 1.0f;
        delayBetweenFades = 1f;
        StartCoroutine(FadeOutAndIn());
    }
    private IEnumerator FadeOutAndIn() {

        while (true) {

            while (_canvasRenderer.GetAlpha() > minAlpha) {
                float newAlpha = Mathf.MoveTowards(_canvasRenderer.GetAlpha(), minAlpha, fadeSpeed * Time.deltaTime);
                _canvasRenderer.SetAlpha(newAlpha);
                yield return null;
            }

            yield return new WaitForSecondsRealtime(delayBetweenFades);

            while (_canvasRenderer.GetAlpha() < maxAlpha) {
                float newAlpha = Mathf.MoveTowards(_canvasRenderer.GetAlpha(), maxAlpha, fadeSpeed * Time.deltaTime);
                _canvasRenderer.SetAlpha(newAlpha);
                yield return null;
            }
            yield return new WaitForSecondsRealtime(delayBetweenFades);
        }
    }
}