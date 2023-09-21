using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //samenvatting in dit script kunnen we aangeven hoeveel waipoints we willen zetten en de waypoint kunnen zien via gizmos. 

    [SerializeField] private Vector3[] WayPoints;

    public Vector3[] Points => WayPoints;

    public Vector3 CurrentPosition => _currentPosition;

    private Vector3 _currentPosition;
    private bool _gameStarted;

    private void Start()
    {
        _gameStarted = true;
        _currentPosition = transform.position;
    }

    public Vector3 GetWaypointsPosition(int index)
    {
        return CurrentPosition + Points[index];
    }

    private void OnDrawGizmos()
    { 
        if (!_gameStarted && transform.hasChanged)
        {
            _currentPosition = transform.position;
        }

        for (int i = 0; i < WayPoints.Length; i++)
        {
            //dt maakt een zwarte sphere precies op de waipoints 
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(WayPoints[i] + _currentPosition, 0.5f);

            if(i < WayPoints.Length - 1)
            {
                //dit laat een lijn zien van de ene waypoint naar de andere 
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(WayPoints[i] + _currentPosition, WayPoints[i + 1] + _currentPosition);
            }
        }
    }
    public Vector3[] getWaypoints()
    {
        return Points;
    }
}
