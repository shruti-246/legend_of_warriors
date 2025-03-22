using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Btst_Set
{
    private GameObject settingsObj;
    private SetManager settingsManager;
    private Slider volumeSlider;
    private TMP_Dropdown graphicsDropdown;

    [SetUp]
    public void Setup()
    {
        settingsObj = new GameObject("SettingsManager");
        settingsManager = settingsObj.AddComponent<SetManager>();

        volumeSlider = settingsObj.AddComponent<Slider>();
        graphicsDropdown = settingsObj.AddComponent<TMP_Dropdown>();

        settingsManager.volumeSlider = volumeSlider;
        settingsManager.graphicsDropdown = graphicsDropdown;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(settingsObj);
    }

    [Test]
    public void Btst_MinVolume()
    {
        settingsManager.ApplyVolume(0.0f);
        Assert.AreEqual(0.0f, AudioListener.volume);
    }

    [Test]
    public void Btst_MaxVolume()
    {
        settingsManager.ApplyVolume(1.0f);
        Assert.AreEqual(1.0f, AudioListener.volume);
    }

    [Test]
    public void Btst_LowestGraphicsQuality()
    {
        settingsManager.ApplyGraphicsQuality(0);
        Assert.AreEqual(0, QualitySettings.GetQualityLevel());
    }

    [Test]
    public void Btst_HighestGraphicsQuality()
    {
        int max = QualitySettings.names.Length - 1;
        settingsManager.ApplyGraphicsQuality(max);
        Assert.AreEqual(max, QualitySettings.GetQualityLevel());
    }
}
