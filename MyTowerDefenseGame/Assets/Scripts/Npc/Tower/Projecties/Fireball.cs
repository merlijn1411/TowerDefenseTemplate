using UnityEngine;

public class Fireball : Projectile
{
    private void Update()
    {
        SeekTarget();
        PointArrived();
    }
    
    public void Seek(Vector3 newTarget)
    {
        Target = newTarget;
    }
}