using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    public float speed = 10f; 
    public float damage = 10f;

    private Transform target;

    public float destroyDelay = 1.0f;
    private float destroyTimer = 0.0f;

    private void Start()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        if(target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            float destroySelfDistance = 0.3f;
            if (Vector3.Distance(transform.position, target.position) < destroySelfDistance)
            {
                Destroy(gameObject);
            }
        }
        if (target == null)
        {
            destroyTimer += Time.deltaTime;
            if (destroyTimer >= destroyDelay)
            {
                Destroy(gameObject);
            }
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
                Destroy(gameObject);
            }
        }
    }

    public void Seek(Transform newTarget)
    {
        target = newTarget;
    }
}
