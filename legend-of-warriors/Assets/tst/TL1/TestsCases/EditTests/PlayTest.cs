using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ControlsPanelNavigationTest
{
    [Test]
    public void ControlsPanelTogglesCorrectlyFromPause()
    {
        // Arrange
        GameObject pausePanel = new GameObject("PausePanel");
        GameObject controlsPanel = new GameObject("ControlsPanel");
        pausePanel.SetActive(true);
        controlsPanel.SetActive(false);

        var playObj = new GameObject("PlayObject");
        Play playScript = playObj.AddComponent<Play>();
        playScript.pausePanel = pausePanel;
        playScript.controlsPanel = controlsPanel;

        // Act: Open Controls
        playScript.OpenControls();

        // Assert: Controls should be active, pause hidden
        Assert.IsTrue(controlsPanel.activeSelf, "Controls Panel should be shown.");
        Assert.IsFalse(pausePanel.activeSelf, "Pause Panel should be hidden.");

        // Act: Close Controls
        playScript.CloseControls();

        // Assert: Controls hidden, pause shown again
        Assert.IsFalse(controlsPanel.activeSelf, "Controls Panel should be hidden after closing.");
        Assert.IsTrue(pausePanel.activeSelf, "Pause Panel should be visible again.");
    }
}
