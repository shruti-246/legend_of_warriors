using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Menu  // Inherits from a base Menu class
{
    public GameObject helpPanel;
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public GameObject achievementsPanel;

    public AudioSource audioSource;     // Reference to the audio source
    public AudioClip clickSound;        // The button click sound clip

    private void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    // Dynamic binding via override
    public override void OpenMenu()
    {
        PlayClickSound();
        mainMenuPanel.SetActive(true);
    }

    public override void CloseMenu()
    {
        PlayClickSound();
        mainMenuPanel.SetActive(false);
    }

    public virtual void OpenPlay()
    {
        PlayClickSound();
        SceneManager.LoadScene("difficulty");
    }

    public virtual void OpenShop()
    {
        PlayClickSound();
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }

    public virtual void QuitGame()
    {
        PlayClickSound();
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public virtual void OpenSettings()
    {
        PlayClickSound();
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        Debug.Log("Settings opened.");
    }

    public virtual void ToggleHelp()
    {
        PlayClickSound();
        if (helpPanel != null)
        {
            helpPanel.SetActive(!helpPanel.activeSelf);
            Debug.Log("Toggled help panel.");
        }
        else
        {
            Debug.LogWarning("Help Panel not assigned.");
        }
    }

    public void OpenAchievements()
    {
        PlayClickSound();
        mainMenuPanel.SetActive(false);
        achievementsPanel.SetActive(true);
    }

    public void CloseAchievements()
    {
        PlayClickSound();
        achievementsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public virtual void BackToMainMenu()
    {
        PlayClickSound();

        if (helpPanel != null && helpPanel.activeSelf)
            helpPanel.SetActive(false);

        if (settingsPanel != null && settingsPanel.activeSelf)
            settingsPanel.SetActive(false);

        mainMenuPanel.SetActive(true);
        Debug.Log("Returned to main menu.");
    }
}
