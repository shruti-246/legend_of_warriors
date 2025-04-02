using UnityEngine;
using UnityEngine.UI;  // For UI elements (Slider, Dropdown, Toggle)
using TMPro;

public class SetManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public GameObject audioPanel;
    public GameObject graphicsPanel;
    public GameObject controlsPanel;
    public PopupMessage popupMessage;

    [Header("Audio Settings")]
    public Slider volumeSlider;
    public Toggle muteToggle;

    [Header("Graphics Settings")]
    public TMP_Dropdown graphicsDropdown;
    public Toggle fullscreenToggle;
    private float volume; // exposed via methods only
    private bool isMuted;
    void Start()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
        LoadSettings();
        ApplyInitialSettings();
    }

    void LoadSettings()
    {
        if (volumeSlider != null)
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 5.0f);

        if (graphicsDropdown != null)
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);

        if (fullscreenToggle != null)
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        if (muteToggle != null)
            muteToggle.isOn = PlayerPrefs.GetInt("Muted", 0) == 1;
    }

    void ApplyInitialSettings()
    {
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

    public void ShowAudioPanel()
    {
        audioPanel.SetActive(true);
        graphicsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void ShowGraphicsPanel()
    {
        audioPanel.SetActive(false);
        graphicsPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void ShowControlsPanel()
    {
        audioPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void CloseControlsPanel()
    {
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ApplyVolume(float volume)
    {
        AudioListener.volume = (muteToggle != null && muteToggle.isOn) ? 0f : volume;
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

    public void ApplyAudioSettings()
    {
        ApplyVolume(volumeSlider.value);
        ApplyMute(muteToggle.isOn);
        popupMessage.ShowMessage("Applied audio settings.");
        Debug.Log("Audio settings applied.");
        ShowSettingsPanel();
    }

    public void DiscardAudioSettings()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 5.0f);
        muteToggle.isOn = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplyMute(muteToggle.isOn);
        popupMessage.ShowMessage("No Audio Changes applied");
        Debug.Log("Audio settings discarded.");
        ShowSettingsPanel();
    }

    public void ApplyGraphicsSettings()
    {
        ApplyGraphicsQuality(graphicsDropdown.value);
        ApplyFullscreen(fullscreenToggle.isOn);
        popupMessage.ShowMessage("Applied graphics settings.");
        Debug.Log("Graphics settings applied.");
        ShowSettingsPanel();
    }

    public void DiscardGraphicsSettings()
    {
        graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        ApplyFullscreen(fullscreenToggle.isOn);
        popupMessage.ShowMessage("No Graphics changes applied");
        Debug.Log("Graphics settings discarded.");
        ShowSettingsPanel();
    }

    public void ApplySettings()
    {
        ApplyVolume(volumeSlider.value);
        ApplyGraphicsQuality(graphicsDropdown.value);
        ApplyFullscreen(fullscreenToggle.isOn);
        ApplyMute(muteToggle.isOn);
        popupMessage.ShowMessage("All setings applied!");
        PlayerPrefs.Save();

        Debug.Log("All settings applied.");

        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void DiscardAllSettings()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 5.0f);
        graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        muteToggle.isOn = PlayerPrefs.GetInt("Muted", 0) == 1;
        popupMessage.ShowMessage("All settings discarded.");

        ApplyInitialSettings();

        Debug.Log("All settings discarded.");

        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    private void ShowSettingsPanel()
    {
        audioPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
