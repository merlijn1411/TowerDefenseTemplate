using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    public float attackRange = 5f; 
    public float attackCooldown = 2f; 
    public GameObject ArrowPrefab; 
    public Transform firePoint; 

    [HideInInspector] public Transform target; 
    private float lastAttackTime;

    public AudioSource fireSource;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void Update()
    {
        FindNearestEnemy();

        if (target != null && Time.time - lastAttackTime >= attackCooldown)
        {
            fireSource.Play();
            Shoot();
            lastAttackTime = Time.time;
        }
    }

    private void FindNearestEnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        var shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        if(nearestEnemy is not null && shortestDistance <= attackRange)
        {
            target = nearestEnemy;
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(ArrowPrefab, firePoint.position, firePoint.rotation);
        var ArrowScript = bullet.GetComponent<ProjectileArrow>();

        ArrowScript?.Seek(target);
    }
}