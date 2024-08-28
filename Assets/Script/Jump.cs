using UnityEngine;
using UnityEngine.UI;

public class MobileJumpButton : MonoBehaviour
{
    public GameObject player; 
    public float jumpForce = 5f; 
    public bool isGrounded;  
    private Rigidbody rb;
    public Animator animator;

    void Start()
    {
        

        rb = player.GetComponent<Rigidbody>();
       
    }

    public void OnJumpButtonDown()
    {
        
        if (isGrounded)
        {
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {

            isGrounded = true;
            animator.SetBool("IsJumping", false);

        
    }
}
