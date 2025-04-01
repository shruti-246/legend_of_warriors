using UnityEngine;
using TMPro;

public class PopupMessage : MonoBehaviour
{
    public GameObject popupPanel;
    public TMP_Text popupText;
    public float duration = 2f;

    private Coroutine popupCoroutine;

    public void ShowMessage(string message)
    {
        if (popupCoroutine != null)
            StopCoroutine(popupCoroutine);

        popupText.text = message;
        popupPanel.SetActive(true);

        popupCoroutine = StartCoroutine(HideAfterDelay());
    }

    private System.Collections.IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(duration);
        popupPanel.SetActive(false);
    }
}
