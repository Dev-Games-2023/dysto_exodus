using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int bulletDamage;

    // public Vector2 direction;
    // public float speed = 20;
    // public Vector2 velocity;

    // void Start()
    // {
    //     Destroy(gameObject, 3);
    // }

    // void Update()
    // {
    //     velocity = speed * transform.up;
    // }

    // private void FixedUpdate()
    // {
    //     Vector2 pos = transform.position;
    //     pos += velocity * Time.fixedDeltaTime;
    //     transform.position = pos;
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

}
