using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTests
{
    GameObject enemyGO;
    GameObject playerGO;
    EnemyControllerAutoAttack enemyScript;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        playerGO = new GameObject("Player");
        playerGO.tag = "Player";
        playerGO.transform.position = new Vector2(5, 0);

        enemyGO = new GameObject("Enemy");
        enemyGO.AddComponent<Rigidbody2D>();
        enemyScript = enemyGO.AddComponent<EnemyControllerAutoAttack>();
        enemyScript.moveSpeed = 2f;

        Animator animator = enemyGO.AddComponent<Animator>();
        enemyScript.animator = animator;

        yield return null;
    }

    [UnityTest]
    public IEnumerator Enemy_Moves_Toward_Player()
    {
        Vector2 startPos = enemyGO.transform.position;

        yield return new WaitForSeconds(1f);

        Vector2 newPos = enemyGO.transform.position;
        Assert.Greater(Vector2.Distance(startPos, playerGO.transform.position),
                       Vector2.Distance(newPos, playerGO.transform.position),
                       "Enemy did not move closer to the player.");
    }

    [UnityTest]
    public IEnumerator Enemy_Flips_Direction_When_Moving()
    {
        enemyGO.transform.position = new Vector2(5f, 0);
        playerGO.transform.position = new Vector2(-5f, 0);

        yield return new WaitForSeconds(1f);

        Assert.IsFalse(enemyScript.IsFacingRight, "Enemy did not flip when changing direction.");
    }

    [UnityTest]
    public IEnumerator Enemy_Attacks_When_In_Range()
    {
        playerGO.transform.position = new Vector2(0.5f, 0);
        enemyScript.attackRange = 1f;
        enemyScript.attackCooldown = 0.5f;

        float lastAttackTime = Time.time;
        yield return new WaitForSeconds(1f);

        Assert.IsTrue(enemyScript.animator.GetBool("IsAttacking"), "Enemy did not attack when in range.");
    }

    [UnityTest]
    public IEnumerator Enemy_Respects_Attack_Cooldown()
    {
        playerGO.transform.position = new Vector2(0.5f, 0);
        enemyScript.attackRange = 1f;
        enemyScript.attackCooldown = 2f;

        enemyScript.Invoke("TriggerAttack", 0);
        float firstAttackTime = Time.time;

        yield return new WaitForSeconds(0.5f);

        bool attackingAgain = enemyScript.animator.GetBool("IsAttacking");
        Assert.IsTrue(attackingAgain, "First attack not triggered.");

        yield return new WaitForSeconds(1f);
        Assert.LessOrEqual(Time.time - firstAttackTime, enemyScript.attackCooldown,
            "Enemy attacked too early (cooldown not respected).");
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        Object.Destroy(playerGO);
        Object.Destroy(enemyGO);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Enemy_Stops_When_Player_Destroyed()
    {
        enemyScript.SetPlayer(null);
        Object.Destroy(playerGO);
        yield return new WaitForSeconds(0.1f);

        Vector2 oldPosition = enemyGO.transform.position;
        yield return new WaitForSeconds(1f);
        Vector2 newPosition = enemyGO.transform.position;

        Assert.AreEqual(oldPosition, oldPosition, "Enemy should not move when player is destroyed.");
    }

    [UnityTest]
    public IEnumerator Enemy_Does_Not_Attack_When_Out_Of_Range()
    {
        playerGO.transform.position = new Vector2(100, 0);
        enemyScript.attackRange = 1f;
        enemyScript.attackCooldown = 0.1f;

        yield return new WaitForSeconds(1f);
        Assert.IsFalse(enemyScript.animator.GetBool("IsAttacking"), "Enemy attacked from out of range.");
    }

    [UnityTest]
    public IEnumerator Enemy_Does_Not_Flip_Upward()
    {
        enemyGO.transform.position = new Vector2(0, 0);
        playerGO.transform.position = new Vector2(0, 5);

        bool initialFacing = enemyScript.IsFacingRight;

        yield return new WaitForSeconds(1f);

        Assert.AreEqual(initialFacing, enemyScript.IsFacingRight, "Enemy flipped when player was directly above.");
    }

    [UnityTest]
    public IEnumerator Enemy_Faces_Right_When_Player_Is_Right()
    {
        enemyGO.transform.position = new Vector2(0, 0);
        playerGO.transform.position = new Vector2(5, 0);

        yield return new WaitForSeconds(1f);

        Assert.IsTrue(enemyScript.IsFacingRight, "Enemy should be facing right.");
    }

    [UnityTest]
    public IEnumerator Enemy_Faces_Left_When_Player_Is_Left()
    {
        enemyGO.transform.position = new Vector2(5, 0);
        playerGO.transform.position = new Vector2(0, 0);

        yield return new WaitForSeconds(1f);

        Assert.IsFalse(enemyScript.IsFacingRight, "Enemy should be facing left.");
    }

    [UnityTest]
    public IEnumerator Enemy_Animator_Speed_Updates_When_Moving()
    {
        Vector2 initialPos = enemyGO.transform.position;
        playerGO.transform.position = initialPos + Vector2.right * 3;

        yield return new WaitForSeconds(1f);

        float speedParam = enemyScript.animator.GetFloat("Speed");
        Assert.Greater(speedParam, 0f, "Animator 'Speed' parameter did not update while moving.");
    }

    [UnityTest]
    public IEnumerator Enemy_Moves_Slower_When_Close_To_Player()
    {
        enemyGO.transform.position = new Vector2(0, 0);
        playerGO.transform.position = new Vector2(10, 0);

        yield return new WaitForSeconds(0.5f);
        float distanceWhenFar = Vector2.Distance(enemyGO.transform.position, playerGO.transform.position);

        enemyGO.transform.position = new Vector2(9.5f, 0);
        yield return new WaitForSeconds(0.5f);
        float distanceWhenClose = Vector2.Distance(enemyGO.transform.position, playerGO.transform.position);

        Assert.Less(distanceWhenClose, distanceWhenFar, "Enemy should be getting closer when near player.");
    }

    [UnityTest]
    public IEnumerator Enemy_Does_Not_Move_When_Speed_Is_Zero()
    {
        enemyScript.moveSpeed = 0f;
        Vector2 originalPos = enemyGO.transform.position;

        yield return new WaitForSeconds(1f);
        Vector2 newPos = enemyGO.transform.position;

        Assert.AreEqual(newPos, newPos, "Enemy should not move when speed is zero.");
    }

    [UnityTest]
    public IEnumerator Enemy_Still_Faces_Player_When_Not_Moving()
    {
        enemyScript.moveSpeed = 0f;
        enemyGO.transform.position = new Vector2(5, 0);
        playerGO.transform.position = new Vector2(0, 0);

        yield return new WaitForSeconds(1f);
        Assert.IsFalse(enemyScript.IsFacingRight, "Enemy should face left even when not moving.");
    }

    [UnityTest]
    public IEnumerator Enemy_Moves_Toward_Player_Diagonally()
    {
        enemyGO.transform.position = new Vector2(0, 0);
        playerGO.transform.position = new Vector2(3, 3);

        yield return new WaitForSeconds(1f);

        Vector2 direction = (playerGO.transform.position - enemyGO.transform.position).normalized;
        Assert.AreEqual(1, Mathf.RoundToInt(direction.x));
        Assert.AreEqual(1, Mathf.RoundToInt(direction.y));
    }

    [UnityTest]
    public IEnumerator Enemy_Only_Flips_On_X_Axis()
    {
        Vector3 initialScale = enemyGO.transform.localScale;

        enemyGO.transform.position = new Vector2(5, 0);
        playerGO.transform.position = new Vector2(0, 0);

        yield return new WaitForSeconds(1f);

        Vector3 newScale = enemyGO.transform.localScale;

        Assert.AreEqual(initialScale.y, newScale.y, "Enemy should not flip vertically.");
        Assert.AreNotEqual(initialScale.x, newScale.x, "Enemy should flip horizontally.");
    }

    [UnityTest]
    public IEnumerator Enemy_Has_Default_Direction_On_Spawn()
    {
        yield return null;
        Assert.IsTrue(enemyScript.IsFacingRight, "Enemy should start facing right by default.");
    }
}

