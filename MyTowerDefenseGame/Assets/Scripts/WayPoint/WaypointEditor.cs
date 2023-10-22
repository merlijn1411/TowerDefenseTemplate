using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]

public class WaypointEditor : Editor
{   
    private Waypoint Waypoint => target as Waypoint;

    private void OnSceneGUI()
    {
        for (int i = 0; i < Waypoint.Waypoints.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector3 currentWaypointPoint = Waypoint.transform.position + Waypoint.Waypoints[i];
            Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint,
                Quaternion.identity, 0.7f,
                new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            EditorGUI.EndChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Move Handle");
                Waypoint.Waypoints[i] = newWaypointPoint - Waypoint.transform.position;
            }
        }
    }
}