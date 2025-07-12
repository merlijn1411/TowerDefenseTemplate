using UnityEngine;

public class Arrow : ProjectileCurving
{
    private void Update()
    {
        SeekTarget();
        PointArrived();
    }
    
   
    public void Seek(Vector3 newTarget, float maxHeight)
    {
        Target = newTarget;
        projectileMaxHeight = maxHeight;
    }
    
}
