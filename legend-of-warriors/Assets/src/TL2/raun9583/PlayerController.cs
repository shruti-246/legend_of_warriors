// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public float moveSpeed = 3f; // Speed of the character
//     public Animator animator;   // Reference to the Animator component

//     // Public property to allow testing of the facing direction
//     public bool IsFacingRight { get; private set; } = true; // Tracks whether the character is facing right

//     void Update()
//     {
//         // Get horizontal input (A/D keys or left/right arrow keys)
//         float moveInput = Input.GetAxis("Horizontal");

//         // Calculate movement direction
//         Vector3 moveDirection = new Vector3(moveInput, 0, 0).normalized;

//         // Move the character
//         transform.position += moveDirection * moveSpeed * Time.deltaTime;

//         // Flip the character if moving in the opposite direction
//         if (moveInput > 0 && !IsFacingRight)
//         {
//             Flip();
//         }
//         else if (moveInput < 0 && IsFacingRight)
//         {
//             Flip();
//         }

//         // Update the Animator parameters based on input
//         animator.SetFloat("Speed", Mathf.Abs(moveInput));

//         // Trigger attacks based on key presses
//         if (Input.GetKeyDown(KeyCode.Q))
//         {
//             TriggerAttack(1); // Attack1
//         }
//         else if (Input.GetKeyDown(KeyCode.E))
//         {
//             TriggerAttack(2); // Attack2
//         }
//         else if (Input.GetKeyDown(KeyCode.R))
//         {
//             TriggerAttack(3); // Attack3
//         }
//     }

//     // Trigger attack and set related Animator parameters
//     public void TriggerAttack(int attackNumber)
//     {
//         animator.SetBool("IsAttacking", true);
//         animator.SetInteger("AttackType", attackNumber);

//         // Optionally, reset IsAttacking after some time
//         Invoke(nameof(ResetAttack), 0.5f); // Adjust timing based on attack duration
//     }

//     // Reset attack state in Animator
//     void ResetAttack()
//     {
//         animator.SetBool("IsAttacking", false);
//     }

//     // Flip the character by changing the scale (mirror effect)
//     void Flip()
//     {
//         IsFacingRight = !IsFacingRight;
//         Vector3 currentScale = transform.localScale;
//         currentScale.x *= -1; // Invert the X-axis scale
//         transform.localScale = currentScale;
//     }
// }







using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the character
    public Animator animator;   // Reference to the Animator component

    // Public property to allow testing of the facing direction
    public bool IsFacingRight { get; private set; } = true; // Tracks whether the character is facing right

    void Update()
    {
        // Get input from horizontal and vertical axes
        float moveInputX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveInputY = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(moveInputX, moveInputY, 0).normalized;

        // Move the character
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Flip the character only when moving left/right
        if (moveInputX > 0 && !IsFacingRight)
        {
            Flip();
        }
        else if (moveInputX < 0 && IsFacingRight)
        {
            Flip();
        }

        // Update the Animator parameters
        animator.SetFloat("Speed", moveDirection.magnitude); // Use magnitude for overall movement
        animator.SetFloat("MoveX", moveInputX);              // Optional: use for directional blend tree
        animator.SetFloat("MoveY", moveInputY);              // Optional: use for directional blend tree

        // Trigger attacks based on key presses
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TriggerAttack(1); // Attack1
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerAttack(2); // Attack2
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            TriggerAttack(3); // Attack3
        }
    }

    // Trigger attack and set related Animator parameters
    public void TriggerAttack(int attackNumber)
    {
        animator.SetBool("IsAttacking", true);
        animator.SetInteger("AttackType", attackNumber);

        // Optionally, reset IsAttacking after some time
        Invoke(nameof(ResetAttack), 0.5f); // Adjust timing based on attack duration
    }

    // Reset attack state in Animator
    void ResetAttack()
    {
        animator.SetBool("IsAttacking", false);
    }

    // Flip the character by changing the scale (mirror effect)
    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
