using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject helpPanel;  // Assign this in Inspector
    public GameObject settingsPanel;  // Assign this in Inspector
    public GameObject MainMenu;  // Assign this in Inspector

    // Function to start the game
    public void PlayGame()
    {
        SceneManager.LoadScene("main-game-scene"); // Replace with your actual game scene name
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Quits the game (only works in a built application)
    }

    // Function to open settings
    public void OpenSettings()
    {
        // Deactivate the main menu and activate the settings panel
        MainMenu.SetActive(false);
        settingsPanel.SetActive(true);
    }

    // Function to open the shop
    public void OpenShop()
    {
        Debug.Log("Shop Opened");
        // Add code to open shop UI
    }

    // Function to toggle the Help Panel
    public void ToggleHelp()
    {
        if (helpPanel != null)
        {
            helpPanel.SetActive(!helpPanel.activeSelf);
        }
        else
        {
            Debug.LogWarning("Help Panel is not assigned in the Inspector.");
        }
    }

    // Function to handle the back button from Help or Settings
    public void OnBackButtonClicked()
    {
        // Check which panel is active and deactivate it
        if (helpPanel.activeSelf)
        {
            helpPanel.SetActive(false);
        }
        else if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }

        // Activate the main menu again
        MainMenu.SetActive(true);
    }
}
