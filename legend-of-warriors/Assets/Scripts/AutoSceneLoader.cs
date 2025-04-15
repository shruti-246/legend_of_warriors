using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneLoader : MonoBehaviour
{
    [Tooltip("Time in seconds before loading the next scene.")]
    public float delayInSeconds = 30f;

    [Tooltip("Name of the next scene to load.")]
    public string nextSceneName = "main-game-scene";

    void Start()
    {
        Invoke(nameof(LoadNextScene), delayInSeconds);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}