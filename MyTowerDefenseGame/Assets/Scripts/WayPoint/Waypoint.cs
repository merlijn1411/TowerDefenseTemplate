using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Vector3[] Waypoints;

    public Transform startPoint;

    public static Waypoint main;

    private void Awake()
    {
        main = this;    
    }

    public Vector3 GetWaypointPosition(int index)
    {
        if (index >= 0 && index < Waypoints.Length)
        {
            return transform.position + Waypoints[index];
        }
        else
        {
            Debug.LogWarning("geen waypoint detected");
            return Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < Waypoints.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position + Waypoints[i], 0.5f);

            if (i < Waypoints.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(transform.position + Waypoints[i], transform.position + Waypoints[i + 1]);
            }
        }
    }
}
