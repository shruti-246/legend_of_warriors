using UnityEngine;
using UnityEngine.UI;

public class UIManagerPlayer : MonoBehaviour
{
    public static UIManagerPlayer Instance;

    public Slider playerHealthSlider; // Drag the Slider from Canvas here

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdatePlayerHealthUI(int currentHealth)
    {
        if (playerHealthSlider != null)
        {
            playerHealthSlider.value = currentHealth;
        }
    }
}
