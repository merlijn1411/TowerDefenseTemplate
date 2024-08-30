using UnityEngine;

public class Fireball : Projectille,IProjectileCalculationTravel
{
    private void Update()
    {
        CalculationTravel();
    }

    public void CalculationTravel()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * (speed * Time.deltaTime));

        if(target is null)
        {
            Destroy(gameObject);
        }
    }

    public void Seek(Transform newTarget)
    {
        target = newTarget;
    }
}