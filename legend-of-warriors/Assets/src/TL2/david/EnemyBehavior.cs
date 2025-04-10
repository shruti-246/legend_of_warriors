using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject winCanvas;
    public float speed = 10f;               // Movement speed toward the player
    public float attackRange = 1.5f;        // Distance at which the enemy will attack
    public int attackDamage = 10;           // Damage inflicted on attack
    public float attackCooldown = 3f;       // Time delay between attacks

    private Transform player;
    private Animator animator;
    private float lastAttackTime;
    private bool facingRight = false;

    [Header("Health")]
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject healthBarPrefab;
    private GameObject healthBarInstance;
    private Slider healthSlider;

    private Vector3 healthBarOffset = new Vector3(0, 2f, 0);

    private float autoDamageTimer = 0f;
    public float autoDamageInterval = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        if (healthBarPrefab != null)
        {
            Vector3 barPosition = transform.position + healthBarOffset;
            healthBarInstance = Instantiate(healthBarPrefab, barPosition, Quaternion.identity);
            healthSlider = healthBarInstance.GetComponentInChildren<Slider>();

            healthSlider.minValue = 0;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
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

        FlipTowardsPlayer();
        UpdateHealthBarPosition();

        autoDamageTimer += Time.deltaTime;
        if (autoDamageTimer >= autoDamageInterval)
        {
            TakeDamage(15);
            autoDamageTimer = 0f;
            autoDamageInterval = Random.Range(1f, 10f);
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        animator.SetBool("isWalking", true);
    }

    void AttackPlayer()
    {
        animator.SetBool("isWalking", false);

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            int attackIndex = Random.Range(1, 4);
            animator.SetInteger("AttackType", attackIndex);
            animator.SetTrigger("DoAttack");

            lastAttackTime = Time.time;
        }
    }

    void FlipTowardsPlayer()
    {
        if ((player.position.x < transform.position.x && facingRight) ||
            (player.position.x > transform.position.x && !facingRight))
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    void UpdateHealthBarPosition()
    {
        if (healthBarInstance != null)
        {
            Vector3 newPosition = transform.position + healthBarOffset;
            newPosition.z = transform.position.z;
            healthBarInstance.transform.position = newPosition;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        if (healthBarInstance != null)
            Destroy(healthBarInstance);

        if(winCanvas != null)
            winCanvas.SetActive(true);

        Destroy(gameObject);
    }
}