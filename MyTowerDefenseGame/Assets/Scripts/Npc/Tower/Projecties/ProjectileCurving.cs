using System;
using UnityEngine;

public class ProjectileCurving : MonoBehaviour
{
    private Transform _target;
    
    private float _moveSpeed;
    private float _trajectoryRelativeMaxHeight;
    
    protected AnimationCurve trajectoryCurve;
    protected AnimationCurve axisCorrectionTrajectoryCurve;

    private Vector3 _trajectoryStartPoint;
    
    private float _distanceToTargetReached = 1f;

    protected void Start()
    {
        _trajectoryStartPoint = transform.position;
    }

    protected void Update()
    {
        SeekTarget();

        if (Vector3.Distance(transform.position, _target.position) < _distanceToTargetReached)
            Destroy(gameObject);
    }

    protected void SeekTarget()
    {
        var trajectoryRange = _target.position - _trajectoryStartPoint;

        var nextPosX = transform.position.x + _moveSpeed * Time.deltaTime;
        var nextPosXNorm = (nextPosX - _trajectoryStartPoint.x) / trajectoryRange.x;

        var nextPosYNorm = trajectoryCurve.Evaluate(nextPosXNorm);
        
        var nextPosYCorrectionNormalized = axisCorrectionTrajectoryCurve.Evaluate(nextPosXNorm);
        var nextPosYCorrectionAbs = nextPosYCorrectionNormalized * trajectoryRange.y;
        
        var nextPosY = _trajectoryStartPoint.y + nextPosYNorm * _trajectoryRelativeMaxHeight + nextPosYCorrectionAbs;

        var newPos = new Vector3(nextPosX, nextPosY, 0);
        
        transform.position = newPos;

    }

    public void InitializeProjectile(Transform target, float moveSpeed, float trajectoryMaxHeight)
    {
        _target = target;
        _moveSpeed = moveSpeed;

        var xDistanceToTarget = target.position.x - transform.position.x;
        _trajectoryRelativeMaxHeight = Mathf.Abs(xDistanceToTarget) * trajectoryMaxHeight;
    }
    
    public void InitializeAnimationCurve(AnimationCurve trajectoryCurve, AnimationCurve axisCorrectionTrajectoryCurve)
    {
        this.trajectoryCurve = trajectoryCurve;
        this.axisCorrectionTrajectoryCurve = axisCorrectionTrajectoryCurve;
    }
}
