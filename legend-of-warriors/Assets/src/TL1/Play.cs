using UnityEngine;

public class Play : MonoBehaviour
{
    public bool isStarted = false;
    public bool isPaused = false;

    [Header("UI Panels")]
    public GameObject pauseMenu; // Assign Pause Panel here

    void Start()
    {
        StartGame(); // auto-start when scene loads
    }

    public void StartGame()
    {
        isStarted = true;
        isPaused = false;
        Time.timeScale = 1f;
        if (pauseMenu != null) pauseMenu.SetActive(false);
        Debug.Log("Game Started");
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pauseMenu != null) pauseMenu.SetActive(true);
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pauseMenu != null) pauseMenu.SetActive(false);
        Debug.Log("Game Resumed");
    }
}
