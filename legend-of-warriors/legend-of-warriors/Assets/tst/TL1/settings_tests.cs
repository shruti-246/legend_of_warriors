// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class SettingsTests
// {
//     private SetManager settingsManager;
//     private Slider volumeSlider;
//     private TMP_Dropdown graphicsDropdown;

//     [SetUp]
//     public void Setup()
//     {
//         GameObject settingsObj = new GameObject();
//         settingsManager = settingsObj.AddComponent<SetManager>();

//         volumeSlider = settingsObj.AddComponent<Slider>();
//         graphicsDropdown = settingsObj.AddComponent<TMP_Dropdown>();

//         settingsManager.volumeSlider = volumeSlider;
//         settingsManager.graphicsDropdown = graphicsDropdown;
//     }

//     [Test]
//     public void Test_MinVolume()
//     {
//         settingsManager.ApplyVolume(0.0f);
//         Assert.AreEqual(0.0f, AudioListener.volume);
//     }

//     [Test]
//     public void Test_MaxVolume()
//     {
//         settingsManager.ApplyVolume(1.0f);
//         Assert.AreEqual(1.0f, AudioListener.volume);
//     }

//     [Test]
//     public void Test_LowestGraphicsQuality()
//     {
//         settingsManager.ApplyGraphicsQuality(0);
//         Assert.AreEqual(0, QualitySettings.GetQualityLevel());
//     }

//     [Test]
//     public void Test_HighestGraphicsQuality()
//     {
//         int maxQuality = QualitySettings.names.Length - 1;
//         settingsManager.ApplyGraphicsQuality(maxQuality);
//         Assert.AreEqual(maxQuality, QualitySettings.GetQualityLevel());
//     }
// }
