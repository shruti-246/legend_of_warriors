using UnityEngine;
using TMPro;

public class PopupMessage : MonoBehaviour
{
    //Singleton with thread safety
    private static PopupMessage instance;
    private static readonly object lockObj = new object();

    public static PopupMessage Instance
    {
        get
        {
            lock (lockObj)
            {
                return instance;
            }
        }
        private set
        {
            lock (lockObj)
            {
                instance = value;
            }
        }
    }

    //Assigned from Inspector (only used in Awake)
    [Header("Popup Setup")]
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private float duration = 2f;

    //Private Class Data instance
    private PopupUIData popupData;
    private Coroutine currentPopup;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Use private class to encapsulate UI fields
        popupData = new PopupUIData(popupPanel, popupText, duration);
    }

    public void ShowMessage(string message)
    {
        if (currentPopup != null)
            StopCoroutine(currentPopup);

        popupData.GetText().text = message;
        popupData.GetPanel().SetActive(true);
        currentPopup = StartCoroutine(HideAfterDelay());
    }

    private System.Collections.IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(popupData.GetDuration());
        popupData.GetPanel().SetActive(false);
        currentPopup = null;
    }

    //Private Class Data Pattern
    private class PopupUIData
    {
        private GameObject panel;
        private TMP_Text text;
        private float duration;

        public PopupUIData(GameObject panel, TMP_Text text, float duration)
        {
            this.panel = panel;
            this.text = text;
            this.duration = duration;
        }

        public GameObject GetPanel()
        {
            return panel;
        }

        public TMP_Text GetText()
        {
            return text;
        }

        public float GetDuration()
        {
            return duration;
        }
    }
}
