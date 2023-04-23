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
        if (Time.frameCount % 6 == 0)
        {
            transform.position += direction * speed * Time.deltaTime;
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, overlapCircle);
            foreach (Collider2D c in hit)
            {
                Enemy enemy = c.GetComponent<Enemy>();
                if (enemy != null)
                {
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
    }
}
