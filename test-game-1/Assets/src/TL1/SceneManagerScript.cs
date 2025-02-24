using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Load Shop scene additively
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }
    // Return to the Main Menu from the Shop scene
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("game-lobby", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Shop");
    }
}
