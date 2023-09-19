using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFireball : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    private Transform target;

    private void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if(target == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public void Seek(Transform newTarget)
    {
        target = newTarget;
    }
}