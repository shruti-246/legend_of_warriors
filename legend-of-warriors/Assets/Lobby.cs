using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    public void GoToLobby()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("game-lobby");
    }
}
