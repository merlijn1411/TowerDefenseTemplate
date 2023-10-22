using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Diagnostics;

public class ArcherTower : MonoBehaviour
{
    public float attackRange = 5f; 
    public float attackCooldown = 2f; 
    public GameObject ArrowPrefab; 
    public Transform firePoint; 

    private Transform target; 
    private float lastAttackTime;

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
            Shoot();
            lastAttackTime = Time.time;
        }
    }

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        if (nearestEnemy != null && shortestDistance <= attackRange)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(ArrowPrefab, firePoint.position, firePoint.rotation);
        ProjectileArrow ArrowScript = bullet.GetComponent<ProjectileArrow>();

        if (ArrowScript != null)
        {
            ArrowScript.Seek(target);
        }
    }
}