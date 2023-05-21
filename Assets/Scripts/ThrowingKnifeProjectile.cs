using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeProjectile : MonoBehaviour
{
    public float speed;
    public float overlapCircle = 0.7f;
    public int damage;

    private bool hitDetected = false;
    private Vector3 direction;

    private float ttl = 6f;

    /// <summary>
    /// Sets the direction of the projectile based on the given x and y values.
    /// </summary>
    /// <param name="dir_x">The x component of the direction.</param>
    /// <param name="dir_y">The y component of the direction.</param>
    /// <remarks>
    /// If the x component is negative, the projectile is flipped horizontally and rotated by 180 degrees.
    /// </remarks>
    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);
        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            Quaternion rotation = transform.localRotation;
            rotation.z = rotation.z * -1;
            scale.x = scale.x * -1;
            transform.localScale = scale;
            transform.localRotation = rotation;
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Move the projectile in the direction and speed given, check for collisions with enemies every 6 frames, and destroy the projectile if an enemy is hit
        transform.position += direction * speed * Time.deltaTime;

        if (Time.frameCount % 6 == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, overlapCircle);
            foreach (Collider2D c in hit)
            {
                Enemy enemy = c.GetComponent<Enemy>();
                if (enemy != null)
                {
                    PostDamage(damage, transform.position);
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if (hitDetected)
            {
                Destroy(gameObject);
            }
        }
        // Decrease the time to live (ttl) by the elapsed time and destroy the game object if ttl is less than zero
        ttl -= Time.deltaTime;
        if (ttl < 0f)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Posts a damage message to the MessageSystem instance. 
    /// </summary>
    /// <param name="damage">The amount of damage to display.</param>
    /// <param name="worldPosition">The world position of the message.</param>
    public void PostDamage(int damage, Vector3 worldPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), worldPosition);
    }    
}
