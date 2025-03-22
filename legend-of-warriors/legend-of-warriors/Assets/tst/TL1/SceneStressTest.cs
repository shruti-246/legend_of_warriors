// using NUnit.Framework;
// using UnityEngine.SceneManagement;
// using System.Collections;
// using UnityEngine.TestTools;

// public class SceneStressTest
// {
//     [UnityTest]
//     public IEnumerator Test_RapidSceneSwitching()
//     {
//         for (int i = 0; i < 50; i++)
//         {
//             SceneManager.LoadScene("Shop", LoadSceneMode.Single);
//             yield return new WaitForSeconds(0.1f);
//             SceneManager.LoadScene("game-lobby", LoadSceneMode.Single);
//             yield return new WaitForSeconds(0.1f);
//         }

//         Assert.AreEqual("game-lobby", SceneManager.GetActiveScene().name);
//     }
// }
