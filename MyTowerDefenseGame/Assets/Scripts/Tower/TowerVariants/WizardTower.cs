using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WizardTower : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackCooldown = 2f;
    public GameObject FireBallPrefab;
    public Transform firePoint;

    private Transform target;
    private float lastAttackTime;

    public AudioSource fireBallSound;

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
            fireBallSound.Play();
            Shoot();
            lastAttackTime = Time.time;
        }
    }

    private void FindNearestEnemy()
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

    private void Shoot()
    {
        GameObject FireBall = Instantiate(FireBallPrefab, firePoint.position, firePoint.rotation);
        ProjectileFireball FireballScript = FireBall.GetComponent<ProjectileFireball>();

        if (FireballScript != null)
        {
            FireballScript.Seek(target);
        }
    }
}
