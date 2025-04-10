using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class playerTetsing
{
    private GameObject playerObject;
    private PlayerController playerController;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Load your actual test scene
        SceneManager.LoadScene("main-game-scene");
        yield return new WaitForSeconds(1f); // Wait for scene to fully load

        // Assuming the Player has a "Player" tag in the scene
        playerObject = GameObject.FindWithTag("Player");
        Assert.IsNotNull(playerObject, "Player object not found in scene!");

        playerController = playerObject.GetComponent<PlayerController>();
        Assert.IsNotNull(playerController, "PlayerController script not found on Player object.");
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator StressAttackTest()
    {
        for (int i = 0; i < 10; i++)
        {
            int attackType = (i % 3) + 1;
            playerController.TriggerAttack(attackType);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        Animator animator = playerController.animator;
            Assert.IsFalse(animator.GetBool("IsAttacking"), "Attack state should have reset after stress.");
        }

    [UnityTest]
    public IEnumerator LowerBoundMovementTest()
    {
        float initialX = playerObject.transform.position.x;

        // Simulate minimal movement
        playerObject.transform.position += Vector3.right * playerController.moveSpeed * Time.deltaTime;
        yield return null;

        float newX = playerObject.transform.position.x;
        Assert.Greater(newX, initialX, "Player should have moved to the right.");
    }

    [UnityTest]
    public IEnumerator UpperBoundMovementTest()
    {
        float initialX = playerObject.transform.position.x;

        float duration = 2f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            playerObject.transform.position += Vector3.right * playerController.moveSpeed * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }

        float finalX = playerObject.transform.position.x;
        Assert.Greater(finalX, initialX + 0.5f, "Player should have moved significantly.");
    }

}
