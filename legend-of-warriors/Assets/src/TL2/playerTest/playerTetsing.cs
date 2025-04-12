// using System.Collections;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using UnityEngine.SceneManagement;

// public class playerTetsing
// {
//     private GameObject playerObject;
//     private PlayerController playerController;

//     [UnitySetUp]
//     public IEnumerator SetUp()
//     {
//         // Load your actual test scene
//         SceneManager.LoadScene("main-game-scene");
//         yield return new WaitForSeconds(1f); // Wait for scene to fully load

//         // Assuming the Player has a "Player" tag in the scene
//         playerObject = GameObject.FindWithTag("Player");
//         Assert.IsNotNull(playerObject, "Player object not found in scene!");

//         playerController = playerObject.GetComponent<PlayerController>();
//         Assert.IsNotNull(playerController, "PlayerController script not found on Player object.");
//     }
//     // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
//     // `yield return null;` to skip a frame.
//     [UnityTest]
//     public IEnumerator StressAttackTest()
//     {
//         for (int i = 0; i < 10; i++)
//         {
//             int attackType = (i % 3) + 1;
//             playerController.TriggerAttack(attackType);
//             // playerController.PerformAttack(attackType, 1);
//             yield return new WaitForSeconds(0.1f);
//         }

//         yield return new WaitForSeconds(1f);

//         Animator animator = playerController.animator;
//             Assert.IsFalse(animator.GetBool("IsAttacking"), "Attack state should have reset after stress.");
//         }

//     [UnityTest]
//     public IEnumerator LowerBoundMovementTest()
//     {
//         float initialX = playerObject.transform.position.x;

//         // Simulate minimal movement
//         playerObject.transform.position += Vector3.right * playerController.moveSpeed * Time.deltaTime;
//         yield return null;

//         float newX = playerObject.transform.position.x;
//         Assert.Greater(newX, initialX, "Player should have moved to the right.");
//     }

//     [UnityTest]
//     public IEnumerator UpperBoundMovementTest()
//     {
//         float initialX = playerObject.transform.position.x;

//         float duration = 2f;
//         float elapsed = 0f;
//         while (elapsed < duration)
//         {
//             playerObject.transform.position += Vector3.right * playerController.moveSpeed * Time.deltaTime;
//             elapsed += Time.deltaTime;
//             yield return null;
//         }

//         float finalX = playerObject.transform.position.x;
//         Assert.Greater(finalX, initialX + 0.5f, "Player should have moved significantly.");
//     }

// }











// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using System.Collections;

// public class PlayerGameplayTests
// {
//     GameObject player;
//     PlayerStats stats;
//     PlayerController controller;
//     Animator animator;

//     [SetUp]
//     public void Setup()
//     {
//         player = GameObject.Instantiate(Resources.Load<GameObject>("TestPlayer"));
//         stats = player.GetComponent<PlayerStats>();
//         controller = player.GetComponent<PlayerController>();
//         animator = player.GetComponent<Animator>();
//     }

//     [TearDown]
//     public void Teardown()
//     {
//         GameObject.Destroy(player);
//     }

//     [UnityTest]
//     public IEnumerator PlayerMovesWithInput()
//     {
//         float initialX = player.transform.position.x;

//         // Simulate input
//         controller.enabled = true;
//         yield return new WaitForSeconds(0.1f);

//         player.transform.position += Vector3.right * stats.attackPower;
//         yield return new WaitForSeconds(0.1f);

//         Assert.Greater(player.transform.position.x, initialX);
//     }

//     [Test]
//     public void PlayerTakesDamageProperly()
//     {
//         int initialHealth = stats.health;
//         stats.TakeDamage(10);
//         Assert.AreEqual(initialHealth - 10, stats.health);
//     }

//     [Test]
//     public void PlayerDoesNotDropBelowZeroHP()
//     {
//         stats.TakeDamage(9999);
//         Assert.AreEqual(0, stats.health);
//     }

//     [Test]
//     public void PlayerTriggersDeathState()
//     {
//         stats.TakeDamage(stats.health);
//         Assert.IsTrue(animator.GetBool("IsDead"));
//     }

//     [Test]
//     public void CriticalOnlyInCombo()
//     {
//         int baseDamage = stats.attackPower;

//         int nonComboDamage = DamageCalculation.CalculateDamage(stats, "Attack1", false);
//         int comboDamage = DamageCalculation.CalculateDamage(stats, "Attack1", true);

//         Assert.GreaterOrEqual(comboDamage, nonComboDamage);
//     }
// }
