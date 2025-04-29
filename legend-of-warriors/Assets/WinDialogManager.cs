using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDialogManager : MonoBehaviour
{
    public static bool isWinDialogOpen = false;

    public GameObject winDialogBox;

    void Start()
    {
        if (winDialogBox != null)
        {
            winDialogBox.SetActive(false);
        }
    }

    public void ShowWinDialog()
    {
        if (winDialogBox != null)
        {
            winDialogBox.SetActive(true);
            isWinDialogOpen = true;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("game-lobby");
    }
}