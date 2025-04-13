using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetManager : MonoBehaviour
{
    private float lastSavedVolume;
    private bool lastSavedMuted;

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
    // Used for dynamic binding (STATIC TYPE = superclass)
    private SettingValue currentSetting; // Static type = SettingValue

    [Header("Click Sound")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    private float volume;
    private bool isMuted;

    [Header("Debug")]
    public TMP_Text volumeDebugText;


    void Start()
    {
        #if UNITY_EDITOR
            PlayerPrefs.DeleteAll();
        #endif
        LoadSettings();
        ApplyInitialSettings();
    }

    private void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    void LoadSettings()
    {
        lastSavedVolume = PlayerPrefs.GetFloat("Volume", 5.0f);
        lastSavedMuted = PlayerPrefs.GetInt("Muted", 0) == 1;

        if (volumeSlider != null)
            volumeSlider.value = lastSavedVolume;

        if (graphicsDropdown != null)
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);

        if (fullscreenToggle != null)
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        if (muteToggle != null)
            muteToggle.isOn = lastSavedMuted;
    }
    void ApplyInitialSettings()
    {
        if (volumeSlider != null)
            ApplyVolume(volumeSlider.value, true); //apply & save

        if (graphicsDropdown != null)
            ApplyGraphicsQuality(graphicsDropdown.value);

        if (fullscreenToggle != null)
            ApplyFullscreen(fullscreenToggle.isOn);

        if (muteToggle != null)
            ApplyMute(muteToggle.isOn);
    }

    public void OpenSet()
    {
        PlayClickSound();
        settingsPanel.SetActive(true);
    }

    public void CloseSet()
    {
        PlayClickSound();
        settingsPanel.SetActive(false);
    }

    public void ShowAudioPanel()
    {
        PlayClickSound();
        audioPanel.SetActive(true);
        graphicsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void ShowGraphicsPanel()
    {
        PlayClickSound();
        audioPanel.SetActive(false);
        graphicsPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void ShowControlsPanel()
    {
        PlayClickSound();
        audioPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void CloseControlsPanel()
    {
        PlayClickSound();
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ApplyVolume(float volume, bool save)
    {
        // Call dynamic Apply
        SettingValue setting = new VolumeSetting(volume);
        //VolumeSetting setting = new VolumeSetting(volume);
        setting.Apply(save);
        currentSetting = setting;

        //After calling Apply, force slider to match real volume
        float actual = AudioListener.volume;
        volumeSlider.value = actual; //reflect true applied volume
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
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    public void ApplyAudioSettings()
    {
        PlayClickSound();
        ApplyVolume(volumeSlider.value, true); //save it
        ApplyMute(muteToggle.isOn);
        popupMessage.ShowMessage("Applied audio settings.");
        Debug.Log("Audio settings applied.");
        ShowSettingsPanel();
    }

    public void DiscardAudioSettings()
    {
        PlayClickSound();

        if (volumeSlider != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume", 5.0f);
            volumeSlider.value = savedVolume;
            ApplyVolume(savedVolume, false); //don’t save it
        }

        if (muteToggle != null)
            muteToggle.isOn = PlayerPrefs.GetInt("Muted", 0) == 1;

        ApplyMute(muteToggle != null && muteToggle.isOn);

        popupMessage.ShowMessage("No Audio Changes applied");
        Debug.Log("Audio settings discarded.");
        ShowSettingsPanel();
    }

    public void ApplyGraphicsSettings()
    {
        PlayClickSound();
        ApplyGraphicsQuality(graphicsDropdown.value);
        ApplyFullscreen(fullscreenToggle.isOn);
        popupMessage.ShowMessage("Applied graphics settings.");
        Debug.Log("Graphics settings applied.");
        ShowSettingsPanel();
    }

    public void DiscardGraphicsSettings()
    {
        PlayClickSound();
        if (graphicsDropdown != null)
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 2);
        if (fullscreenToggle != null)
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        ApplyFullscreen(fullscreenToggle != null && fullscreenToggle.isOn);
        popupMessage.ShowMessage("No Graphics changes applied");
        Debug.Log("Graphics settings discarded.");
        ShowSettingsPanel();
    }

    public void ApplySettings()
    {
        PlayClickSound();
        ApplyVolume(volumeSlider.value, true); //apply & save;
        ApplyGraphicsQuality(graphicsDropdown.value);
        ApplyFullscreen(fullscreenToggle.isOn);
        ApplyMute(muteToggle.isOn);

        //Update saved values
        lastSavedVolume = volumeSlider.value;
        lastSavedMuted = muteToggle.isOn;

        PlayerPrefs.Save();
        popupMessage.ShowMessage("All settings applied!");
        Debug.Log("All settings applied.");
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
