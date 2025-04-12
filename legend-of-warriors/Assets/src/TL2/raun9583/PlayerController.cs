using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Animator animator;


    public EnemyBehavior enemyRef;                 // Drag the enemy here
    public PlayerStats playerStats;           // Link to player logic
    public bool IsFacingRight { get; private set; } = true;

    void Start()
    {

        //  Debug.Log(typeof(EnemyBehavior)); // Just to check if compiler sees it

        // Attach player logic script (make sure it's on the same GameObject)
        playerStats = GetComponent<PlayerStats>();
        if (playerStats == null)
        {
            Debug.LogError("Player logic (Player.cs) not found!");
        }

        // Optional: Init enemy
        if (enemyRef == null)
        {
            Debug.LogWarning("Enemy not assigned in PlayerController!");
        }
    }

    void Update()
    {
        HandleMovement();
        HandleAttackInput();
    }

    void HandleMovement()
    {
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveInputX, moveInputY, 0).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (moveInputX > 0 && !IsFacingRight) Flip();
        else if (moveInputX < 0 && IsFacingRight) Flip();

        animator.SetFloat("Speed", moveDirection.magnitude);
        animator.SetFloat("MoveX", moveInputX);
        animator.SetFloat("MoveY", moveInputY);
    }

    void HandleAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Q)) PerformAttack("Attack1", 1);
        else if (Input.GetKeyDown(KeyCode.E)) PerformAttack("Attack2", 2);
        else if (Input.GetKeyDown(KeyCode.R)) PerformAttack("Attack3", 3);

        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O))
        {
            playerStats.PerformCombo(enemyRef);
        }
    }

    public void PerformAttack(string attackType, int animTrigger)
    {
        if (enemyRef != null)
        {
            playerStats.PerformAttack(enemyRef, attackType); // Backend damage logic
        }

        animator.SetBool("IsAttacking", true);
        animator.SetInteger("AttackType", animTrigger);
        Invoke(nameof(ResetAttack), 0.5f);
    }

    void ResetAttack()
    {
        animator.SetBool("IsAttacking", false);
    }

    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    // For testing: lets you trigger a basic attack without needing parameters
    public void TriggerAttack(int attackNumber)
    {
        string attackName = "Attack" + attackNumber; // Makes "Attack1", "Attack2", etc.
        PerformAttack(attackName, attackNumber);
    }


}




