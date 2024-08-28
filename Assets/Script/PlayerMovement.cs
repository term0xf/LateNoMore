using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;
    public Transform cameraTransform;
    public static Animator animator;
    public static Vector3 movement = Vector3.zero;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        animator = GetComponent<Animator>();

        // Set Rigidbody collision detection to Continuous for better collision handling
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Ensure drag settings are appropriate
        rb.drag = 0f; // No drag for natural falling
        rb.angularDrag = 0.05f; // Minimal angular drag

        // Ensure gravity is enabled
        rb.useGravity = true;
    }

    private void FixedUpdate()
    {
        // Move direction is always relative to the camera's forward and right direction
        Vector3 moveDirection = cameraTransform.forward * movement.z + cameraTransform.right * movement.x;
        moveDirection.y = 0; // Ensure no vertical movement

        if (movement != Vector3.zero)
        {
            // Set the player's velocity directly to control the speed precisely
            rb.velocity = moveDirection.normalized * moveSpeed + new Vector3(0, rb.velocity.y, 0);

            // Rotate the player to face the movement direction
            RotatePlayer(moveDirection);
        }
        else
        {
            // Stop horizontal movement when no input is detected
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    private void RotatePlayer(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
        }
    }

    public void MoveUpPressed()
    {
        movement = new Vector3(0, 0, 1);
        animator.SetBool("IsMoving", true);
    }

    public void MoveDownPressed()
    {
        movement = new Vector3(0, 0, -1);
        animator.SetBool("IsMoving", true);
    }

    public void MoveLeftPressed()
    {
        movement = new Vector3(-1, 0, 0);
        animator.SetBool("IsMoving", true);
    }

    public void MoveRightPressed()
    {
        movement = new Vector3(1, 0, 0);
        animator.SetBool("IsMoving", true);
    }

    public static void StopMovement()
    {
        movement = Vector3.zero;
        animator.SetBool("IsMoving", false);
        animator.SetBool("IsJumping", false);
    }
}
