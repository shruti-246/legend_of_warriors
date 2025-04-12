using UnityEngine;

public class EnemyControllerAutoAttack : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;

    [Header("References")]
    public Animator animator;

    private Rigidbody2D rb;
    private Transform player;
    private Vector2 movement;
    private float lastAttackTime;

    public bool IsFacingRight { get; private set; } = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player GameObject has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Move towards the player
        Vector2 direction = (player.position - transform.position).normalized;
        movement = direction;

        // Animate movement
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        // Flip sprite based on direction
        if (movement.x > 0 && !IsFacingRight)
            Flip();
        else if (movement.x < 0 && IsFacingRight)
            Flip();

        // Attack if in range and cooldown elapsed
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            TriggerAttack(Random.Range(1, 4)); // Attack 1, 2, or 3
            lastAttackTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void TriggerAttack(int attackNumber)
    {
        if (animator == null) return;

        animator.SetBool("IsAttacking", true);
        animator.SetInteger("AttackType", attackNumber);
        Invoke(nameof(ResetAttack), 0.5f); // Reset after 0.5s
    }

    void ResetAttack()
    {
        if (animator != null)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}