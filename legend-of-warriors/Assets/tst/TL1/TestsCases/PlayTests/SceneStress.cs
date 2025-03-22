using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneStress
{
    private string sceneA = "game-lobby";
    private string sceneB = "Shop";

    // Simple test — not needed for Play Mode stress but here for template completeness
    [Test]
    public void SceneStressSimplePasses()
    {
        Assert.Pass("Scene stress test setup is ready!");
    }

    // Play Mode coroutine test — actual stress test
    [UnityTest]
    public IEnumerator SceneStressWithEnumeratorPasses()
    {
        for (int i = 0; i < 5; i++) // Loop 5 times to simulate stress
        {
            SceneManager.LoadScene(sceneA);
            yield return new WaitForSeconds(0.5f);
            Assert.AreEqual(sceneA, SceneManager.GetActiveScene().name);

            SceneManager.LoadScene(sceneB);
            yield return new WaitForSeconds(0.5f);
            Assert.AreEqual(sceneB, SceneManager.GetActiveScene().name);
        }

        Debug.Log("Successfully switched between 'game-lobby' and 'Shop' multiple times.");
    }
}
