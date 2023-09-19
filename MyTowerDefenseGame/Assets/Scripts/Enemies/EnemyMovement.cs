using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float MoveSpeed;

    protected Vector2 direction;
    public Vector3 CurrentPointPosition { get; private set; }

    private Waypoint waypointManager;

    private int _currentWaypointIndex;


    private void Start()
    {
        waypointManager = FindAnyObjectByType<Waypoint>(); 

        if (waypointManager == null)
        {
            Debug.LogError("Waypoint Script not found in the scene.");
        }
    }

    private void Update()
    {

        CurrentPointPosition = waypointManager.GetWaypointPosition(_currentWaypointIndex);
        Move();
        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, MoveSpeed * Time.deltaTime);
    }

    private bool CurrentPointPositionReached()
    {
        float distanceToNextpointPosition = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextpointPosition < 0.1f)
        {
            CurrentPointPosition = transform.position;
            return true;
        }
        return false;
    }

    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = waypointManager.Waypoints.Length - 1;
        if (_currentWaypointIndex < lastWaypointIndex)
        {
            _currentWaypointIndex++;
        }
        else
        {
            Destroy(gameObject);
            EndPointReached();
        }
    }

    private void EndPointReached()
    {
        Enemy enemyDamage = GetComponent<Enemy>();

        if(enemyDamage != null)
        {
            enemyDamage.TakeDamage();
        }
        
    }
}
