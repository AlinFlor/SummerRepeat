using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // The player's transform
    public Transform cam; // The camera's transform
    public float distance = 5.0f; // Distance between the camera and the player
    public float height = 2.0f; // Height offset for the camera
    public float rotationSpeed = 5.0f; // Speed of camera rotation
    public float moveSpeed = 5.0f; // Speed of player movement

    private float currentX = 0.0f; // X axis rotation
    private float currentY = 0.0f; // Y axis rotation

    void Update()
    {
        // Get mouse input for camera rotation
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, -35, 60); // Clamp the vertical rotation

        // Get input for player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calculate camera-relative direction to move
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
            player.rotation = rotation;

            Vector3 moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
            player.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    void LateUpdate()
    {
        // Calculate the camera's position and rotation
        Vector3 cameraDirection = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // Set the camera's position and look at the player
        transform.position = player.position + rotation * cameraDirection;
        transform.LookAt(player.position + Vector3.up * height);
    }


}
