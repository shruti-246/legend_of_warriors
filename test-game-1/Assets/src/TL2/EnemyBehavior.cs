using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 3f;
    public float attackRange = 1.5f;
    public float defendRange = 2.5f;
    public float collectRange = 5f;
    public int attackDamage = 10;
    public float attackCooldown = 1.5f;

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

        // GameObject collectible = FindClosestCollectible();
        GameObject collectible = null;

        if (collectible != null)
        {
            MoveTowards(collectible.transform.position);
            animator.SetBool("isWalking", true);
        }
        else
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= attackRange)
            {
                AttackPlayer();
            }
            else if (distance <= defendRange)
            {
                Defend();
            }
            else
            {
                MoveTowards(player.position);
                animator.SetBool("isWalking", true);
            }
        }
    }

    void MoveTowards(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        animator.SetBool("isWalking", true);
    }

    void AttackPlayer()
    {
        animator.SetBool("isWalking", false);
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            animator.SetTrigger("Attack");
            // player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            // lastAttackTime = Time.time;
        }
    }

    void Defend()
    {
        animator.SetBool("isWalking", false);
        animator.SetTrigger("Defend");
    }

    // GameObject FindClosestCollectible()
    // {
    //     GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
    //     GameObject closest = null;
    //     float shortestDistance = Mathf.Infinity;

    //     foreach (GameObject item in collectibles)
    //     {
    //         float distance = Vector2.Distance(transform.position, item.transform.position);
    //         if (distance < shortestDistance && distance <= collectRange)
    //         {
    //             shortestDistance = distance;
    //             closest = item;
    //         }
    //     }
    //     return closest;
    // }
}