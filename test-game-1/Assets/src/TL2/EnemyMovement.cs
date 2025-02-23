using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Speed for moving left and right
    public float jumpForce = 10f; // Force applied for jumping
    public float rollSpeed = 7f; // Speed applied for rolling

    [Header("Ground Detection")]
    public Transform groundCheck; // Reference point for ground check
    public float groundCheckRadius = 0.2f; // Radius of ground detection
    public LayerMask groundLayer; // Layer assigned to ground objects

    private Rigidbody2D rb; // Rigidbody2D reference
    private bool isGrounded = false; // Flag to check if grounded

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
    }

    void Update()
    {
        CheckIfGrounded(); // Continuously check if grounded
        HandleMovement();  // Handle player input and movement
    }

    // Check if the enemy is touching the ground using Physics2D.OverlapCircle
    void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Debug log to check ground status
        if (isGrounded)
        {
            Debug.Log("Enemy is on the Ground");
        }
    }

    // Handles all movement inputs
    void HandleMovement()
    {
        // Move Forward (Right Arrow)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        // Move Backward (Left Arrow)
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }

        // Jump (Up Arrow)
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump(Vector2.up);
        }

        // Jump Diagonally Right (Up + Right Arrows)
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && isGrounded)
        {
            Jump(new Vector2(1, 1).normalized);
        }

        // Jump Diagonally Left (Up + Left Arrows)
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && isGrounded)
        {
            Jump(new Vector2(-1, 1).normalized);
        }

        // Kick (Down Arrow)
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Kick();
        }

        // Duck and Roll Right (Down + Right Arrows)
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            DuckAndRoll(Vector2.right);
        }

        // Duck and Roll Left (Down + Left Arrows)
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            DuckAndRoll(Vector2.left);
        }
    }

    // Jump Functionality
    void Jump(Vector2 direction)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset vertical velocity before jump
        rb.AddForce(direction * jumpForce, ForceMode2D.Impulse);
        isGrounded = false; // Prevents double jumping
        Debug.Log("Enemy Jumps");
    }

    // Kick Functionality
    void Kick()
    {
        Debug.Log("Enemy performs a kick!");
        // Add kick animation or logic here
    }

    // Duck and Roll Functionality
    void DuckAndRoll(Vector2 rollDirection)
    {
        Debug.Log("Enemy Ducks and Rolls!");
        rb.AddForce(rollDirection * rollSpeed, ForceMode2D.Impulse);
    }

    // Visual Debugging for Ground Detection in Scene View
    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    // Collision Detection to Reset Grounded Status
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}