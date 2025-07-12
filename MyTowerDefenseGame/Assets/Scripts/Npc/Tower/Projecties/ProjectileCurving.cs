using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCurving : MonoBehaviour
{
    protected AnimationCurve animationCurve;   
   
    public float speed;
    public float damage;
    public float projectileMaxHeight;
    
    private float _arrival = 0.1f;
    private Vector2 _currentVelocity;
    private Vector2 _currentPosition;
    
    public Vector2 Target { get; set; }
    private void Start()
    {
        _currentVelocity = new Vector2(0, 0);
        _currentPosition = transform.position;
    }
    
    protected void SeekTarget()
    {
        var trajectoryRange = Target - _currentPosition;

        var nextPosX = transform.position.x + speed;

        var nextPosXNormalized = (nextPosX - _currentPosition.x) / trajectoryRange.x;
        var nextPosYNormalized = animationCurve.Evaluate(nextPosXNormalized);

        var nextPositionY = _currentPosition.y + nextPosYNormalized * projectileMaxHeight;

        var newPosition = new Vector3(nextPosX, nextPositionY);

        transform.position = newPosition;
    }
    
    public void InitializeAnimationCurve(AnimationCurve targetCurve)
    {
        animationCurve = targetCurve;
    }
    
    protected void PointArrived()
    {
        if (Vector2.Distance(Target,_currentPosition) < _arrival)
        {
            Destroy(gameObject);
        }
    }
}
