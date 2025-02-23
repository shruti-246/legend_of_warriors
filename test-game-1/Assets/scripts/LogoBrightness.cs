using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogoBrightnessAnimator : MonoBehaviour
{
    public Image logoImage; // Reference to the logo image
    public float duration = 1f; // Duration for one brightness cycle
    public float maxBrightness = 1f; // Maximum brightness
    public float minBrightness = 0.3f; // Minimum brightness

    private void Start()
    {
        // Start the brightness animation coroutine
        StartCoroutine(AnimateBrightness());
    }

    private IEnumerator AnimateBrightness()
    {
        while (true) // Loop indefinitely
        {
            // Fade in
            for (float t = 0; t <= duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                Color newColor = logoImage.color;
                newColor.a = Mathf.Lerp(minBrightness, maxBrightness, normalizedTime);
                logoImage.color = newColor;
                yield return null;
            }

            // Fade out
            for (float t = 0; t <= duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                Color newColor = logoImage.color;
                newColor.a = Mathf.Lerp(maxBrightness, minBrightness, normalizedTime);
                logoImage.color = newColor;
                yield return null;
            }
        }
    }
}
