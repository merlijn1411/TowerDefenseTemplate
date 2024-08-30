using UnityEngine;

public class Arrow : Projectille,IProjectileCalculationTravel
{
    public float destroyDelay = 1.0f;
    private float destroyTimer = 0.0f;
    
    private void Update()
    {
        CalculationTravel();
    }
    public void CalculationTravel()
    {
        if (target != null)
        {
            var direction = (target.position - transform.position).normalized;

            transform.position += direction * (speed * Time.deltaTime);

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            var destroySelfDistance = 0.3f;
            if (Vector3.Distance(transform.position, target.position) < destroySelfDistance)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            destroyTimer += Time.deltaTime;
            if (destroyTimer >= destroyDelay)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Seek(Transform newTarget)
    {
        target = newTarget;
    }
    
}
