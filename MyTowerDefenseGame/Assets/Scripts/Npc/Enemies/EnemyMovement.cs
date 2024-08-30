using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemy;
    private Vector3 CurrentPointPosition { get; set; }

    private int _currentWaypointIndex;


    private void Start()
    {
        _enemy = GetComponent<Enemy>();

        if (Waypoint.Main == null)
        {
            Debug.LogError("Waypoint Script not found in the scene.");
        }
    }

    private void Update()
    {
        CurrentPointPosition = Waypoint.Main.GetWaypointPosition(_currentWaypointIndex);
        Move();
        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, _enemy.MoveSpeed * Time.deltaTime);
    }

    private bool CurrentPointPositionReached()
    {
        var distanceToNextpointPosition = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextpointPosition < 0.1f)
        {
            CurrentPointPosition = transform.position;
            return true;
        }
        return false;
    }

    private void UpdateCurrentPointIndex()
    {
        var lastWaypointIndex = Waypoint.Main.Waypoints.Length - 1;
        if (_currentWaypointIndex < lastWaypointIndex)
            _currentWaypointIndex++;
        else
        {
            Destroy(gameObject);
            _enemy.TakeDamage();
        }
    }
}
