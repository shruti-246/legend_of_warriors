using UnityEngine;

public static class DamageCalculation
{
    public static int CalculateDamage(PlayerStats player, string attackType, bool isCombo = false)
    {
        int baseDamage = player.attackPower;
        float attackMultiplier = GetAttackTypeMultiplier(attackType);

        int totalDamage = Mathf.RoundToInt(baseDamage * attackMultiplier);

        if (isCombo && Random.value < player.criticalHitChance)
        {
            totalDamage = Mathf.RoundToInt(totalDamage * 1.5f);
            Debug.Log("⚡ Critical Combo Hit!");
        }

        return totalDamage;
    }

    public static int CalculateDamage(Enemy enemy, string attackType)
    {
        return enemy.attackPower;
    }

    private static float GetAttackTypeMultiplier(string attackType)
    {
        switch (attackType)
        {
            case "Attack1": return 1.0f;
            case "Attack2": return 1.25f;
            case "Attack3": return 1.5f;
            default: return 1.0f;
        }
    }
}
