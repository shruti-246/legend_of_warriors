using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Load Shop scene additively
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
        // Optionally hide the Main Menu panel if you don’t want both to be visible
        // mainMenuPanel.SetActive(false);
    }
    // Return to the Main Menu from the Shop scene
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("game-lobby", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Shop");
        // Optionally show the Main Menu panel if it was hidden
        // mainMenuPanel.SetActive(true);
    }
}
