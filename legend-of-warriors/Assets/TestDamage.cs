using UnityEngine;

public class TestDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth.TakeDamage(20);
            Debug.Log("Test: Damage applied to player.");
        }
    }
}