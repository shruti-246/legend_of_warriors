using UnityEngine;

public class PlayerControllerNew : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 movement;
    public bool IsFacingRight { get; private set; } = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get full 2D input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Update animator if available
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude); // triggers walk/run
        }

        // Flip only when moving left/right
        if (movement.x > 0 && !IsFacingRight)
            Flip();
        else if (movement.x < 0 && IsFacingRight)
            Flip();

        // Attacks
        if (Input.GetKeyDown(KeyCode.Q))
            TriggerAttack(1);
        else if (Input.GetKeyDown(KeyCode.E))
            TriggerAttack(2);
        else if (Input.GetKeyDown(KeyCode.R))
            TriggerAttack(3);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void TriggerAttack(int attackNumber)
    {
        if (animator == null) return;

        animator.SetBool("IsAttacking", true);
        animator.SetInteger("AttackType", attackNumber);
        Invoke(nameof(ResetAttack), 0.5f);
    }

    void ResetAttack()
    {
        if (animator != null)
            animator.SetBool("IsAttacking", false);
    }

    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
