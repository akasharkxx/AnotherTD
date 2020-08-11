using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> gridOfWorld = new Dictionary<Vector2Int, Waypoint>();

    private void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        Waypoint[] waypointsInWorld = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypointTemporary in waypointsInWorld)
        {
            gridOfWorld.Add(waypointTemporary.GetGridPosition(), waypointTemporary);
        }
    }
}
