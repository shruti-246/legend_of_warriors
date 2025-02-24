using UnityEngine;
using UnityEngine.UI;  // Use this for Unity UI elements (Slider, Dropdown)
using TMPro;  // This is for TextMeshPro (in case you're using TMP_Dropdown)

public class SetManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;

    // Change to TMP_Dropdown if you're using TextMesh Pro (for Dropdown UI)
    public TMP_Dropdown graphicsDropdown;  // Use TMP_Dropdown for compatibility
    //public Toggle fullscreenToggle;

    void Start()
    {
        // Safety check for missing UI elements
        if (volumeSlider == null)
            Debug.LogError("Volume Slider is not assigned in the Inspector!", this);
        
        if (graphicsDropdown == null)
            Debug.LogError("Graphics Dropdown is not assigned in the Inspector!", this);

        // Load saved settings only if the components are not null
        if (volumeSlider != null)
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 5.0f);
        
        if (graphicsDropdown != null)
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);

        // Apply settings
        ApplyVolume(volumeSlider.value);
        ApplyGraphicsQuality(graphicsDropdown.value);
        //ApplyFullscreen(fullscreenToggle.isOn);
    }

    public void OpenSet()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSet()
    {
        settingsPanel.SetActive(false);
    }

    public void ApplyVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void ApplyGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
    }

    // public void ApplyFullscreen(bool isFullscreen)
    // {
    //     Screen.fullScreen = isFullscreen;
    //     PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    // }

    public void ApplySettings()
    {
        // Apply and save settings
        if (volumeSlider != null)
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        if (graphicsDropdown != null)
            PlayerPrefs.SetInt("GraphicsQuality", graphicsDropdown.value);

        AudioListener.volume = volumeSlider.value;

        PlayerPrefs.Save(); // Save settings permanently

        Debug.Log("Settings Applied");

        CloseSet();
    }
}
