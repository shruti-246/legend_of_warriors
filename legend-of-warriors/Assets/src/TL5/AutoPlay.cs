using UnityEngine;

public class AutoPlay : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackInterval = 2f;
    private float attackTimer = 0f;

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // Use Vector3.left if player faces left

        // Timed attack
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            Attack();
            attackTimer = 0f;
        }
    }

    void Attack()
    {
        // Fire weapon automatically
        var weapon = GetComponent<PrefabWeapon>();
        if (weapon != null)
        {
            weapon.Shoot(); // Replace with Fire() if that's the method
            Debug.Log("🔥 Auto-fired weapon");
        }
    }
}
