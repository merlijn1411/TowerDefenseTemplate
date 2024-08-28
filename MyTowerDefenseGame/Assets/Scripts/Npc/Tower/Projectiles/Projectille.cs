using UnityEngine;

public class Projectille : MonoBehaviour
{
    public float speed;
    public float damage;

    [HideInInspector] public Transform target;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemyHealth = collision.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
