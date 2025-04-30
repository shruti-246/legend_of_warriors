using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoLoader : MonoBehaviour
{
    public string mainGameSceneName = "main-game-scene"; // Match exact scene name

    void Start()
    {
        DemoState.isDemoMode = true; // Activate demo mode
        SceneManager.LoadScene(mainGameSceneName);
    }
}
