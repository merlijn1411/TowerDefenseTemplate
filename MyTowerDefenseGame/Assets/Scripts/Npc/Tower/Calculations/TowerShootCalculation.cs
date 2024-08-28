using UnityEngine;

public class TowerShootCalculation : MonoBehaviour
{
    protected Transform FindNearestEnemy(float attackRange)
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        var shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

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
