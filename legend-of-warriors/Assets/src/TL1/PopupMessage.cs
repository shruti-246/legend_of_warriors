using UnityEngine;
using TMPro;

public class PopupMessage : MonoBehaviour
{
    public static PopupMessage Instance; // Singleton instance

    [Header("Popup UI")]
    public GameObject popupPanel;     // Assign in Inspector
    public TMP_Text popupText;        // Assign in Inspector
    public float duration = 2f;       // Time before it hides

    private Coroutine currentPopup;   // Track running coroutine

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public void ShowMessage(string message)
    {
        if (currentPopup != null)
            StopCoroutine(currentPopup); // Cancel previous one

        popupText.text = message;
        popupPanel.SetActive(true);

        currentPopup = StartCoroutine(HideAfterDelay());
    }

    private System.Collections.IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(duration);
        popupPanel.SetActive(false);
        currentPopup = null;
    }
}
