using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogoBrightness : MonoBehaviour 
{
    public Image logoImage;
    public float fadeInDuration = 1f;
    public float stayDuration = 2f;
    public float fadeOutDuration = 1f;

    private void Start()
    {
            if (logoImage == null)
        {
            Debug.LogError("❌ logoImage is NULL");
            return;
        }
        else
        {
            Debug.Log("✅ logoImage is assigned: " + logoImage.name);
        }

        if (!logoImage.gameObject.activeInHierarchy)
        {
            Debug.LogWarning("⚠️ logoImage GameObject is inactive when Start runs!");
        }

        StartCoroutine(FadeFromCenter());
    }

    private IEnumerator FadeFromCenter()
    {
        logoImage.transform.localScale = Vector3.zero;
        Color color = logoImage.color;
        color.a = 0f;
        logoImage.color = color;

        for (float t = 0; t <= fadeInDuration; t += Time.deltaTime)
        {
            float progress = t / fadeInDuration;
            logoImage.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, progress);
            color.a = Mathf.Lerp(0f, 1f, progress);
            logoImage.color = color;
            yield return null;
        }

        logoImage.transform.localScale = Vector3.one;
        color.a = 1f;
        logoImage.color = color;

        yield return new WaitForSeconds(stayDuration);

        for (float t = 0; t <= fadeOutDuration; t += Time.deltaTime)
        {
            float progress = t / fadeOutDuration;
            logoImage.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.8f, progress);
            color.a = Mathf.Lerp(1f, 0f, progress);
            logoImage.color = color;
            yield return null;
        }

        logoImage.gameObject.SetActive(false);
    }
}
