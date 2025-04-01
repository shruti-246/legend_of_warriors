using UnityEngine;
using UnityEngine.UI;  // For UI elements (Slider, Dropdown, Toggle)
using TMPro;

public class SetManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public TMP_Dropdown graphicsDropdown;

    public Toggle fullscreenToggle;  // NEW
    public Toggle muteToggle;        // NEW

    void Start()
    {   
        #if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
        #endif
        // Safety checks
        if (volumeSlider == null)
            Debug.LogError("Volume Slider is not assigned!", this);

        if (graphicsDropdown == null)
            Debug.LogError("Graphics Dropdown is not assigned!", this);

        if (fullscreenToggle == null)
            Debug.LogWarning("Fullscreen toggle not assigned!", this);

        if (muteToggle == null)
            Debug.LogWarning("Mute toggle not assigned!", this);

        // Load settings
        if (volumeSlider != null)
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 5.0f);

        if (graphicsDropdown != null)
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);

        if (fullscreenToggle != null)
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        if (muteToggle != null)
            muteToggle.isOn = PlayerPrefs.GetInt("Muted", 0) == 1;

        // Apply initial values
        ApplyVolume(volumeSlider.value);
        ApplyGraphicsQuality(graphicsDropdown.value);
        ApplyFullscreen(fullscreenToggle.isOn);
        ApplyMute(muteToggle.isOn);
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
        AudioListener.volume = muteToggle != null && muteToggle.isOn ? 0f : volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void ApplyGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
    }

    public void ApplyFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }

    public void ApplyMute(bool isMuted)
    {
        AudioListener.volume = isMuted ? 0f : volumeSlider.value;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    public void ApplySettings()
    {
        if (volumeSlider != null)
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        if (graphicsDropdown != null)
            PlayerPrefs.SetInt("GraphicsQuality", graphicsDropdown.value);

        if (fullscreenToggle != null)
            PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);

        if (muteToggle != null)
            PlayerPrefs.SetInt("Muted", muteToggle.isOn ? 1 : 0);

        AudioListener.volume = muteToggle != null && muteToggle.isOn ? 0f : volumeSlider.value;

        PlayerPrefs.Save();

        Debug.Log("Settings Applied");

        CloseSet();
    }
}
