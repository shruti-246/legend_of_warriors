// using System.Collections;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;

// public class DavidTest1
// {
//     private GameObject enemyObject;
//     private EnemyMovement enemyMovement;
//     private Rigidbody2D rb;

//     [SetUp]
//     public void Setup()
//     {
//         // Create a test enemy object with required components
//         enemyObject = new GameObject("TestEnemy");
//         rb = enemyObject.AddComponent<Rigidbody2D>();
//         enemyMovement = enemyObject.AddComponent<EnemyMovement>();

//         // Set default properties
//         enemyMovement.moveSpeed = 5f;
//         enemyMovement.jumpForce = 10f;
//         enemyMovement.rollSpeed = 7f;

//         // Simulate ground detection by creating a ground object
//         GameObject ground = new GameObject("TestGround");
//         ground.layer = LayerMask.NameToLayer("Ground");
//         ground.AddComponent<BoxCollider2D>();

//         // Create a transform for ground check reference
//         GameObject groundCheck = new GameObject("GroundCheck");
//         groundCheck.transform.parent = enemyObject.transform;
//         enemyMovement.groundCheck = groundCheck.transform;
//     }

//     [TearDown]
//     public void Teardown()
//     {
//         // Destroy test objects after each test
//         Object.DestroyImmediate(enemyObject);
//     }

//     [UnityTest]
//     public IEnumerator Enemy_IsGrounded_WhenOnGround()
//     {
//         enemyMovement.isGrounded = false;
//         yield return new WaitForFixedUpdate();
//         Assert.IsTrue(enemyMovement.isGrounded, "Enemy should be grounded when touching the ground.");
//     }

//     [UnityTest]
//     public IEnumerator Enemy_MovesRight_WhenRightArrowPressed()
//     {
//         rb.velocity = Vector2.zero;
//         InputSimulator.SetKey(KeyCode.RightArrow, true);
//         yield return new WaitForSeconds(0.1f);
//         Assert.Greater(rb.velocity.x, 0, "Enemy should move right.");
//     }

//     [UnityTest]
//     public IEnumerator Enemy_MovesLeft_WhenLeftArrowPressed()
//     {
//         rb.velocity = Vector2.zero;
//         InputSimulator.SetKey(KeyCode.LeftArrow, true);
//         yield return new WaitForSeconds(0.1f);
//         Assert.Less(rb.velocity.x, 0, "Enemy should move left.");
//     }

//     [UnityTest]
//     public IEnumerator Enemy_Jumps_WhenUpArrowPressed()
//     {
//         enemyMovement.isGrounded = true;
//         InputSimulator.SetKey(KeyCode.UpArrow, true);
//         yield return new WaitForFixedUpdate();
//         Assert.Greater(rb.velocity.y, 0, "Enemy should jump.");
//     }

//     [UnityTest]
//     public IEnumerator Enemy_DoesNotDoubleJump_WhenNotGrounded()
//     {
//         enemyMovement.isGrounded = false;
//         float initialVelocityY = rb.velocity.y;
//         InputSimulator.SetKey(KeyCode.UpArrow, true);
//         yield return new WaitForFixedUpdate();
//         Assert.AreEqual(initialVelocityY, rb.velocity.y, "Enemy should not double jump.");
//     }

//     [UnityTest]
//     public IEnumerator Enemy_DucksAndRolls_WhenDownAndRightArrowPressed()
//     {
//         InputSimulator.SetKey(KeyCode.DownArrow, true);
//         InputSimulator.SetKey(KeyCode.RightArrow, true);
//         yield return new WaitForSeconds(0.1f);
//         Assert.Greater(rb.velocity.x, 0, "Enemy should roll right.");
//     }

//     [UnityTest]
//     public IEnumerator Enemy_DucksAndRolls_WhenDownAndLeftArrowPressed()
//     {
//         InputSimulator.SetKey(KeyCode.DownArrow, true);
//         InputSimulator.SetKey(KeyCode.LeftArrow, true);
//         yield return new WaitForSeconds(0.1f);
//         Assert.Less(rb.velocity.x, 0, "Enemy should roll left.");
//     }

//     [UnityTest]
//     public IEnumerator Enemy_Kicks_WhenDownArrowPressed()
//     {
//         bool kicked = false;
//         enemyMovement.Kick = () => kicked = true;
//         InputSimulator.SetKey(KeyCode.DownArrow, true);
//         yield return new WaitForFixedUpdate();
//         Assert.IsTrue(kicked, "Enemy should perform a kick.");
//     }
// }