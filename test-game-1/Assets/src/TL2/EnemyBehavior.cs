using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 10f;               // Movement speed toward the player
    public float attackRange = 1.5f;       // Distance at which the enemy will attack
    public int attackDamage = 10;          // Damage inflicted on attack
    public float attackCooldown = 3f;    // Time delay between attacks
    private Transform player;
    private Animator animator;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            AttackPlayer();
        }
        else
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate direction toward the player
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // Set running animation
        animator.SetBool("isWalking", true);
    }

    void AttackPlayer()
    {
        animator.SetBool("isWalking", false);

        // Attack only after cooldown
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            animator.SetTrigger("Attack");
            lastAttackTime = Time.time;
        }
    }
}