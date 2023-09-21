using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]

public class WaypointEditor : Editor
{
    //dit script laat me de waypoint verplaatsen zonder de Inspector te gebruiken.
    Waypoint Waypoint => target as Waypoint;
    private void OnSceneGUI()
    {
        for(int i = 0; i < Waypoint.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            //dit maakt de Handle om de waypoint te verplaatsen. 
            Vector3 currenWaypointPoint = Waypoint.CurrentPosition + Waypoint.Points[i];
            Vector3 newWaypointPoint = Handles.FreeMoveHandle(currenWaypointPoint,
                Quaternion.identity, 0.7f,
                new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            EditorGUI.EndChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Move Handle");
                Waypoint.Points[i] = newWaypointPoint - Waypoint.CurrentPosition;
            }
        }
    }
}
