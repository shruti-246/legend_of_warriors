using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEndManager : MonoBehaviour
{
    public TMP_Text messageText;  // Drag your MessageText TMP object here
    public string result = "win"; // Default; override this before loading scene

    void Start()
    {
        // Change message based on result (set before loading scene)
        if (PlayerPrefs.GetString("GameResult", "win") == "win")
        {
            messageText.text = "You Win!";
        }
        else
        {
            messageText.text = "You Lost!";
        }
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("game-lobby");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("difficulty");
    }
}
