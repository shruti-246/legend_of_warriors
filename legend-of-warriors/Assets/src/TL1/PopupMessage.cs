using UnityEngine;
using TMPro;

public class PopupMessage : MonoBehaviour
{
    private static PopupMessage instance;
    private static readonly object lockObj = new object(); // Lock object for atomic access

    public static PopupMessage Instance
    {
        get
        {
            lock (lockObj) // Ensures atomic access
            {
                return instance;
            }
        }
        private set
        {
            lock (lockObj) // Ensures thread-safe assignment
            {
                instance = value;
            }
        }
    }

    [Header("Popup UI")]
    public GameObject popupPanel;   // Assign in Inspector
    public TMP_Text popupText;      // Assign in Inspector
    public float duration = 2f;

    private Coroutine currentPopup;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // To keep persist
    }

    public void ShowMessage(string message)
    {
        if (currentPopup != null)
            StopCoroutine(currentPopup);

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
