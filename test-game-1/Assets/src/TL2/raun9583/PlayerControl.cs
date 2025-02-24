using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the character
    public Animator animator; // Reference to the Animator component

    void Update()
    {
        // Get horizontal input (A/D keys or left/right arrow keys)
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(moveInput, 0, 0).normalized;

        // Move the character
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Update the Animator parameters based on input
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

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
        // else if (Input.GetKeyDown(KeyCode.T))
        // {
        //     animator.SetBool("IsDead", true);
        // }
    }


    void TriggerAttack(int attackNumber)
    {
        animator.SetBool("IsAttacking", true);
        animator.SetInteger("AttackType", attackNumber);
        
        // Optionally, reset isAttacking after some time
        Invoke(nameof(ResetAttack), 0.5f); // Adjust timing based on attack duration
    }

    void ResetAttack()
    {
        animator.SetBool("IsAttacking", false);
    }
}
