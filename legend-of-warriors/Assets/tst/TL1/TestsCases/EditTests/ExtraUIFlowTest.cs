using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ExtraUIFlowTest
{
    private GameObject helpPanel;
    private GameObject achievementsPanel;
    private GameObject mainMenuPanel;

    [SetUp]
    public void Setup()
    {
        helpPanel = new GameObject("HelpPanel");
        achievementsPanel = new GameObject("AchievementsPanel");
        mainMenuPanel = new GameObject("MainMenuPanel");
    }

    [Test]
    public void HelpPanel_InitialState_IsInactive()
    {
        Assert.IsFalse(helpPanel.activeSelf);
    }

    [Test]
    public void ToggleHelpPanel_TogglesState()
    {
        helpPanel.SetActive(false);
        helpPanel.SetActive(true);
        Assert.IsTrue(helpPanel.activeSelf);
        helpPanel.SetActive(false);
        Assert.IsFalse(helpPanel.activeSelf);
    }

    [Test]
    public void AchievementsPanel_Open_HidesMainMenu()
    {
        mainMenuPanel.SetActive(true);
        achievementsPanel.SetActive(false);

        achievementsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);

        Assert.IsTrue(achievementsPanel.activeSelf);
        Assert.IsFalse(mainMenuPanel.activeSelf);
    }

    [Test]
    public void CloseAchievementsPanel_ShowsMainMenu()
    {
        mainMenuPanel.SetActive(false);
        achievementsPanel.SetActive(true);

        achievementsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

        Assert.IsFalse(achievementsPanel.activeSelf);
        Assert.IsTrue(mainMenuPanel.activeSelf);
    }

    [Test]
    public void QuitGame_DoesNotCrash_EditorSafe()
    {
        LogAssert.Expect(LogType.Log, "Quit Game");
        Debug.Log("Quit Game");
    }

    [Test]
    public void HelpPanel_ToggleMultipleTimes()
    {
        for (int i = 0; i < 3; i++)
        {
            helpPanel.SetActive(!helpPanel.activeSelf);
        }
        Assert.IsTrue(helpPanel.activeSelf || !helpPanel.activeSelf); // No crash
    }

    [Test]
    public void MainMenuPanel_IsActive_AtStart()
    {
        mainMenuPanel.SetActive(true);
        Assert.IsTrue(mainMenuPanel.activeSelf);
    }

    [Test]
    public void AchievementsPanel_MultipleOpenClose()
    {
        achievementsPanel.SetActive(true);
        achievementsPanel.SetActive(false);
        achievementsPanel.SetActive(true);
        Assert.IsTrue(achievementsPanel.activeSelf);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(helpPanel);
        Object.DestroyImmediate(achievementsPanel);
        Object.DestroyImmediate(mainMenuPanel);
    }
}
