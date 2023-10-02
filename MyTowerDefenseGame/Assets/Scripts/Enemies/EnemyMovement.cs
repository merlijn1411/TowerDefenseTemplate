using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float MoveSpeed;

    protected Vector2 direction;
    public Vector3 CurrentPointPosition { get; private set; }

    private Waypoint waypointManager;

    private int _currentWaypointIndex;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        waypointManager = FindObjectOfType<Waypoint>();

        if (waypointManager == null)
        {
            Debug.LogError("WaypointManager not found in the scene.");
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
            ChangeAnimation();
            return true;
        }
        return false;
    }

    private void ChangeAnimation()
    {
        Vector2 moveDirection = (CurrentPointPosition - transform.position.normalized);

        float horizontalInput = 0f;

        if (Mathf.Approximately(moveDirection.x, 1.0f))
        {
            
            horizontalInput = 1f;
        }
        else if (Mathf.Approximately(moveDirection.x, -1.0f))
        {
            
            horizontalInput = -1f;
        }

        
        anim.SetFloat("Horizontal", horizontalInput);
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
            EndPointReached();
        }
    }

    private void EndPointReached()
    {
        Destroy(gameObject);
    }
}
