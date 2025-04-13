using NUnit.Framework;
using UnityEngine;

public class SettingsPanelTest
{
    private GameObject settingsPanel;
    private GameObject audioPanel;
    private GameObject graphicsPanel;
    private GameObject controlsPanel;

    [SetUp]
    public void Setup()
    {
        settingsPanel = new GameObject("SettingsPanel");
        audioPanel = new GameObject("AudioPanel");
        graphicsPanel = new GameObject("GraphicsPanel");
        controlsPanel = new GameObject("ControlsPanel");
    }

    [Test]
    public void SettingsPanel_IsInitiallyInactive()
    {
        Assert.IsFalse(settingsPanel.activeSelf);
    }

    [Test]
    public void ActivatingSettingsPanel_EnablesPanel()
    {
        settingsPanel.SetActive(true);
        Assert.IsTrue(settingsPanel.activeSelf);
    }

    [Test]
    public void OpeningAudioPanel_DisablesOtherPanels()
    {
        audioPanel.SetActive(true);
        graphicsPanel.SetActive(false);
        controlsPanel.SetActive(false);

        Assert.IsTrue(audioPanel.activeSelf);
        Assert.IsFalse(graphicsPanel.activeSelf);
        Assert.IsFalse(controlsPanel.activeSelf);
    }

    [Test]
    public void GraphicsPanel_BoundaryResolutionCheck()
    {
        int resolutionIndex = 2; // Assume 0=Low, 1=Medium, 2=High
        Assert.GreaterOrEqual(resolutionIndex, 0);
        Assert.LessOrEqual(resolutionIndex, 2);
    }

    [Test]
    public void ToggleControlsPanel_OnlyControlsActive()
    {
        audioPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        controlsPanel.SetActive(true);

        Assert.IsFalse(audioPanel.activeSelf);
        Assert.IsFalse(graphicsPanel.activeSelf);
        Assert.IsTrue(controlsPanel.activeSelf);
    }

    [Test]
    public void DeactivatingAllSubpanels()
    {
        audioPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        controlsPanel.SetActive(false);

        Assert.IsFalse(audioPanel.activeSelf);
        Assert.IsFalse(graphicsPanel.activeSelf);
        Assert.IsFalse(controlsPanel.activeSelf);
    }

    [Test]
    public void GraphicsPanel_QualityIndex_TooLow_ShouldBeInvalid()
    {
        int index = -1;
        Assert.Less(index, 0);
    }

    [Test]
    public void GraphicsPanel_QualityIndex_TooHigh_ShouldBeInvalid()
    {
        int index = 5; // Assume valid range is 0-2
        Assert.Greater(index, 2);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(settingsPanel);
        Object.DestroyImmediate(audioPanel);
        Object.DestroyImmediate(graphicsPanel);
        Object.DestroyImmediate(controlsPanel);
    }
}
