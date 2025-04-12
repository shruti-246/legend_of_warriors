using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int attackPower = 15;
    public int defensePower = 5;

    public void PerformAttack(PlayerStats player)
    {
        int damage = DamageCalculation.CalculateDamage(this, "EnemyAttack");
        player.TakeDamage(damage);
        Debug.Log($"Enemy attacked Player for {damage} damage!");
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"Enemy took {amount} damage! Remaining HP: {health}");
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}
