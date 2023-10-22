using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ProjectileArrow : MonoBehaviour
{
    public float speed = 10f; 
    public float damage = 10f; 

    private Transform target; 

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
        
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        
        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
