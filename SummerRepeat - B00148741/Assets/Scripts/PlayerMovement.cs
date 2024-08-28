using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public Transform cameraTransform; // Reference to the camera's transform
    private Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent the Rigidbody from rotating due to collisions
    }

    void Update()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get the camera's forward and right directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Keep the movement direction on the horizontal plane (no vertical movement)
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculate the direction to move the player
        Vector3 moveDirection = (forward * moveVertical + right * moveHorizontal).normalized;

        // Move the player using Rigidbody
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
        anim.SetBool("walk", false);

        // Rotate the player to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("walk", true);
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, toRotation, moveSpeed * 10 * Time.deltaTime));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "finishLine")
        {
            SceneManager.LoadScene(4);
        }
    }
}