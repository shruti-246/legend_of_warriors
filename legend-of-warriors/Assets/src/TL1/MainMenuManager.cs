using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Menu  // Inherits from a base Menu class
{
    public GameObject helpPanel;
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public GameObject achievementsPanel;

    // Dynamic binding via override
    public override void OpenMenu()
    {
        mainMenuPanel.SetActive(true);
        Debug.Log("Main menu opened.");
    }

    public override void CloseMenu()
    {
        mainMenuPanel.SetActive(false);
        Debug.Log("Main menu closed.");
    }

    public virtual void OpenPlay()
    {
        Debug.Log("Opening game scene...");
        SceneManager.LoadScene("main-game-scene");
    }

    public virtual void OpenShop()
    {
        Debug.Log("Shop opened.");
        // Can add: SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }

    public virtual void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public virtual void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        Debug.Log("Settings opened.");
    }

    public virtual void ToggleHelp()
    {
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
        mainMenuPanel.SetActive(false);
        achievementsPanel.SetActive(true);
    }

    public void CloseAchievements()
    {
        achievementsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public virtual void BackToMainMenu()
    {
        if (helpPanel != null && helpPanel.activeSelf)
            helpPanel.SetActive(false);

        if (settingsPanel != null && settingsPanel.activeSelf)
            settingsPanel.SetActive(false);

        mainMenuPanel.SetActive(true);
        Debug.Log("Returned to main menu.");
    }
}
