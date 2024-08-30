using UnityEngine;

public class Projectille : MonoBehaviour
{
    public float speed;
    public float damage;

    [HideInInspector] public Transform target;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyHealth = collision.GetComponent<IDamageable>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
