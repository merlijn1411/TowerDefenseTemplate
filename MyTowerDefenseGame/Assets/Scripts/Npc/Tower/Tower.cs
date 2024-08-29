using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData TowerData;
    
    [HideInInspector] public float LastAttackTime;
    [HideInInspector] public Transform Target;
    
    public Transform FirePoint;
    
    protected Transform FindNearestEnemy(float attackRange)
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        var shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector2.Distance(transform.position,enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        if (nearestEnemy is not null && shortestDistance <= attackRange)
        {
            return nearestEnemy;
        }

        return null;
    }
}
