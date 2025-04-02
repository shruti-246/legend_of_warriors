using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public bool isStarted = false;
    public bool isPaused = false;

    [Header("UI Panels")]
    public GameObject pausePanel;         
    public GameObject controlsPanel;      
    void Start()
    {
        StartGame(); // Automatically start game when scene loads
    }

    public void StartGame()
    {
        isStarted = true;
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (controlsPanel != null)
            controlsPanel.SetActive(false);

        Debug.Log("Game Started");
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        Debug.Log("Game Resumed");
    }

    public void OpenControls()
    {
        if (controlsPanel != null)
        {
            controlsPanel.SetActive(true);
            pausePanel.SetActive(false); // Hide pause panel while viewing controls
            Debug.Log("Controls Panel Opened");
        }
    }

    public void CloseControls()
    {
        if (controlsPanel != null)
        {
            controlsPanel.SetActive(false);
            pausePanel.SetActive(true); // Return to pause panel
            Debug.Log("Controls Panel Closed");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Time.timeScale = 1f; // Reset time in case player returns
        SceneManager.LoadScene("game-lobby"); // Replace with your main menu scene
    }
}
