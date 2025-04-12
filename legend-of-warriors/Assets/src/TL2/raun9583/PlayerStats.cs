using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public int health = 100;
    public int attackPower = 2;
    public int defensePower = 2;
    public int energy = 100;
    public float criticalHitChance = 0.2f;

    [Header("Combo")]
    public List<string> comboSequence = new List<string>();

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (UIManagerPlayer.Instance != null && UIManagerPlayer.Instance.playerHealthSlider != null)
        {
            UIManagerPlayer.Instance.playerHealthSlider.maxValue = health;
            UIManagerPlayer.Instance.playerHealthSlider.value = health;
        }
        else
        {
            Debug.LogWarning("UIManagerPlayer or health slider not assigned!");
        }
    }

    public void PerformAttack(EnemyBehavior enemy, string attackType, bool isCombo = false)
    {
        int damage = DamageCalculation.CalculateDamage(this, attackType, isCombo);
        enemy.TakeDamage(damage);
        Debug.Log($"Player used {attackType} {(isCombo ? "(COMBO)" : "")} on Enemy for {damage} damage!");

        TriggerAttackAnimation(attackType);
    }

    public void PerformCombo(EnemyBehavior enemy)
    {
        ComboSystem.ExecuteCombo(this, enemy);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Max(health, 0);

        if (UIManagerPlayer.Instance != null)
        {
            UIManagerPlayer.Instance.UpdatePlayerHealthUI(health);
        }

        Debug.Log($"Player took {amount} damage! Remaining HP: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");

        if (animator != null)
        {
            animator.SetBool("IsDead", true);
        }

        // Disable movement/controls
        GetComponent<PlayerController>().enabled = false;
    }

    private void TriggerAttackAnimation(string attackType)
    {
        if (animator == null) return;

        int attackIndex = attackType switch
        {
            "Attack1" => 1,
            "Attack2" => 2,
            "Attack3" => 3,
            _ => 1
        };

        animator.SetBool("IsAttacking", true);
        animator.SetInteger("AttackType", attackIndex);
        animator.SetTrigger("DoAttack");

        // Reset animation state
        Invoke(nameof(ResetAttackAnimation), 0.5f);
    }

    private void ResetAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}
