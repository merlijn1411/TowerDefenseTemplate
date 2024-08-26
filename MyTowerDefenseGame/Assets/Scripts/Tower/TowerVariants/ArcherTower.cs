using System;
using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    public float attackRange = 5f; 
    public float attackCooldown = 2f; 
    public GameObject ArrowPrefab; 
    public Transform firePoint; 

    private Transform target; 
    private float lastAttackTime;

    private TCAnimaton _tCAnimaton;

    public AudioSource fireSource;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void Start()
    {
        _tCAnimaton = GetComponentInChildren<TCAnimaton>();
    }

    private void Update()
    {
        FindNearestEnemy();

        if (target&& Time.time - lastAttackTime >= attackCooldown)
        {
            _tCAnimaton.StartAnimation(target);
            fireSource.Play();
            Shoot();
            lastAttackTime = Time.time;
        }
        else
            _tCAnimaton.StartAnimation(null); 
        
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

    public bool EnemyInRange(Transform enemy)
    {
        var distanceToEnemy = Vector2.Distance(transform.position, enemy.position);
        return distanceToEnemy < attackRange;
    }

    private void Shoot()
    {
        var bullet = Instantiate(ArrowPrefab, firePoint.position, firePoint.rotation);
        var arrowScript = bullet.GetComponent<ProjectileArrow>();

        arrowScript?.Seek(target);
    }
}