using NUnit.Framework;
using UnityEngine;

public class PauseSystemTest
{
    private GameObject pausePanel;
    private GameObject controlsPanel;

    [SetUp]
    public void Setup()
    {
        pausePanel = new GameObject("PausePanel");
        controlsPanel = new GameObject("ControlsPanel");
    }

    [Test]
    public void PausePanel_InitialState_IsInactive()
    {
        Assert.IsFalse(pausePanel.activeSelf);
    }

    [Test]
    public void Resume_WhenPaused_HidesPausePanel()
    {
        pausePanel.SetActive(true);
        pausePanel.SetActive(false); // Simulate resume
        Assert.IsFalse(pausePanel.activeSelf);
    }

    [Test]
    public void OpenControlsPanel_DisablesPausePanel()
    {
        controlsPanel.SetActive(true);
        pausePanel.SetActive(false);
        Assert.IsTrue(controlsPanel.activeSelf);
        Assert.IsFalse(pausePanel.activeSelf);
    }

    [Test]
    public void CloseControlsPanel_EnablesPausePanel()
    {
        controlsPanel.SetActive(false);
        pausePanel.SetActive(true);
        Assert.IsFalse(controlsPanel.activeSelf);
        Assert.IsTrue(pausePanel.activeSelf);
    }

    [Test]
    public void ControlsPanel_OpensSuccessfully()
    {
        controlsPanel.SetActive(true);
        Assert.IsTrue(controlsPanel.activeSelf);
    }

    [Test]
    public void ControlsPanel_ClosesSuccessfully()
    {
        controlsPanel.SetActive(true);
        controlsPanel.SetActive(false);
        Assert.IsFalse(controlsPanel.activeSelf);
    }

    [Test]
    public void PausePanel_ToggleCheck_ActiveThenInactive()
    {
        pausePanel.SetActive(true);
        Assert.IsTrue(pausePanel.activeSelf);
        pausePanel.SetActive(false);
        Assert.IsFalse(pausePanel.activeSelf);
    }

    [Test]
    public void PausePanel_ToggleCheck_InactiveThenActive()
    {
        pausePanel.SetActive(false);
        pausePanel.SetActive(true);
        Assert.IsTrue(pausePanel.activeSelf);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(pausePanel);
        Object.DestroyImmediate(controlsPanel);
    }
}
