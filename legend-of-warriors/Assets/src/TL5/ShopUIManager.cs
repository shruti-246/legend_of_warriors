using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopUIManager : MonoBehaviour
{
    // This method will be called when the SAVE button is clicked
    public void OnExitToLobby()
    {
        // Make sure the scene name "game-lobby" is spelled correctly
        SceneManager.LoadScene("game-lobby");
    }
}
