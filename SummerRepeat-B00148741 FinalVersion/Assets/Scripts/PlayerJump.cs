using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody rb;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Trigger the jump only once when the space bar is pressed
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        anim.SetBool("jump", true);
        // Apply an upward force to the Rigidbody to make the player jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;  // Set isGrounded to false after jumping
    }

    void OnCollisionEnter(Collision collision)
    {
        anim.SetBool("jump", false);
        // Check if the player has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Reset isGrounded when the player lands
        }
    }
}


