using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ComboSystem
{
    public static void ExecuteCombo(PlayerStats player, EnemyBehavior enemy)
    {
        player.StartCoroutine(PerformComboCoroutine(player, enemy));
    }

    private static IEnumerator PerformComboCoroutine(PlayerStats player, EnemyBehavior enemy)
    {
        List<List<string>> allCombos = new List<List<string>>
        {
            new List<string> { "Attack1", "Attack2" },
            new List<string> { "Attack2", "Attack3" },
            new List<string> { "Attack1", "Attack3" }
        };

        List<string> selectedCombo = allCombos[Random.Range(0, allCombos.Count)];
        Debug.Log($"Combo Executed: {string.Join(" + ", selectedCombo)}");

        foreach (string move in selectedCombo)
        {
            player.PerformAttack(enemy, move, true);
            yield return new WaitForSeconds(0.6f); // Wait for animation to finish
        }
    }
}
