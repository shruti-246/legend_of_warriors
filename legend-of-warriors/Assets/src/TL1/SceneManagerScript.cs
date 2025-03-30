using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public delegate void ApplyChangesDelegate();
    public static event ApplyChangesDelegate OnApplyAll;

    public delegate void DiscardChangesDelegate();
    public static event DiscardChangesDelegate OnDiscardAll;

    // Load the Shop scene
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }

    // Return to the Main Menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("game-lobby", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Shop");
    }

    // Called by "Apply All" button
    public void ApplyAllChanges()
    {
        OnApplyAll?.Invoke(); // Notifies CustomizationPanelManager
        Debug.Log("All selections applied.");
        ReturnToMainMenu();
    }

    // Called by "Discard All" button
    public void DiscardAllChanges()
    {
        OnDiscardAll?.Invoke(); // Notifies CustomizationPanelManager
        Debug.Log("All selections discarded.");
        ReturnToMainMenu();
    }
}
