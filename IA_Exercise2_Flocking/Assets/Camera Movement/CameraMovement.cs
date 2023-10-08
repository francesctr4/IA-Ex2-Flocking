using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Camera position parameters
    public Transform[] waypoints; // Array of waypoint positions
    public float teleportInterval; // Time interval between teleports in seconds

    private int currentWaypoint = 0;
    private float lastTeleportTime;

    private void Start()
    {
        SetWaypoints();
        TeleportToWaypoint(currentWaypoint);
    }

    private void SetWaypoints()
    {
        if (waypoints.Length < 2)
        {
            Debug.LogError("You need at least 2 waypoints for camera teleportation.");
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        if (Time.time - lastTeleportTime >= teleportInterval)
        {

            //if (currentWaypoint < waypoints.Length - 1)
            //{
            //    currentWaypoint++;
            //}

            // Uncomment to loop the camera positions

            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                
                currentWaypoint = 0; // Wrap around to the first waypoint

            }

            TeleportToWaypoint(currentWaypoint);
            lastTeleportTime = Time.time;
        }
        
    }

    private void TeleportToWaypoint(int waypointIndex)
    {
        // Change the position and the rotation of the camera to the next waypoint
        transform.position = waypoints[waypointIndex].position;
        transform.rotation = waypoints[waypointIndex].rotation;
    }

}
