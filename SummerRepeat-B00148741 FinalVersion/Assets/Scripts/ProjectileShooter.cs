using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab to be fired
    public Transform player;            // Reference to the player's transform
    public float fireInterval = 2f;     // Time interval between each shot
    public float projectileSpeed = 10f; // Speed of the projectile

    private float nextFireTime;

    void Start()
    {
        // Set the initial time to fire
        nextFireTime = Time.time + fireInterval;
    }

    void Update()
    {
        // Check if it's time to fire the next projectile
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireInterval; // Set the next fire time
        }
    }

    void FireProjectile()
    {
        // Instantiate the projectile at the current position and rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Apply velocity to the projectile in the direction of the player
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = direction * projectileSpeed;
        Destroy(projectile, 5);
    }
}
