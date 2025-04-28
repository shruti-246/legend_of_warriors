using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public void SelectBCMode()
    {
        GameSettings.CurrentDifficulty = GameSettings.Difficulty.BC;
        SceneManager.LoadScene("new-playground");
    }

    public void SelectMediumMode()
    {
        GameSettings.CurrentDifficulty = GameSettings.Difficulty.Medium;
        SceneManager.LoadScene("new-playground");
    }

    public void SelectImpossibleMode()
    {
        GameSettings.CurrentDifficulty = GameSettings.Difficulty.Impossible;
        SceneManager.LoadScene("new-playground");
    }
}