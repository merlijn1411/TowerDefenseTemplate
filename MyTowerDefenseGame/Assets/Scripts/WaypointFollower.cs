using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    [SerializeField] private Path path;

    [SerializeField] private float speed ;

    [SerializeField] private int nextWaypointIndex = 1;

    [SerializeField] private float reachedWaypointClearance = 0.25f;
    void Awake()
    {
        path = FindAnyObjectByType<Path>();
    }
    void Start()
    {
        transform.position = path.waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        //dit is om de enemy te laten bewegen 
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed);
        //als de enemy zijn checkpoint heeft behaald gaat het naar de volgende 
        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointClearance) 
        {
            nextWaypointIndex = nextWaypointIndex + 1;
        }
        //gaat de route opnieuw af
        if (nextWaypointIndex >= path.waypoints.Length)
        {
            nextWaypointIndex = 0;
        }

    }

}
