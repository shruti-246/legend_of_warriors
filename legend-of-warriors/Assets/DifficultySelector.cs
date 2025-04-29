using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public void SelectBCMode()
    {
        GameSettings.CurrentDifficulty = GameSettings.Difficulty.BC;
        SceneManager.LoadScene("main-game-scene");
    }

    public void SelectMediumMode()
    {
        GameSettings.CurrentDifficulty = GameSettings.Difficulty.Medium;
        SceneManager.LoadScene("main-game-scene");
    }

    public void SelectImpossibleMode()
    {
        GameSettings.CurrentDifficulty = GameSettings.Difficulty.Impossible;
        SceneManager.LoadScene("main-game-scene");
    }
}