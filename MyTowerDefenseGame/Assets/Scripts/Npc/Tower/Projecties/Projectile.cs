using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float mass = 20;
    public bool followPath;

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
        var desiredStep = Target - _currentPosition;
        
        var desiredStepNormalized = desiredStep.normalized;
        
        var desiredVelocity = desiredStepNormalized * speed;
        var steeringStep = desiredVelocity - _currentVelocity;
        
        var steeringForce = steeringStep / mass;
        _currentVelocity += steeringForce;
        
        _currentPosition += _currentVelocity * Time.deltaTime;
        transform.position = _currentPosition;
        
        
        if (followPath)
        {
            var angle = Mathf.Atan2(_currentVelocity.y, _currentVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

   
    protected void PointArrived()
    {
        if (Vector2.Distance(Target,_currentPosition) < _arrival)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyHealth = collision.GetComponent<IDamageable>();

        enemyHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
}
