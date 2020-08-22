using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField]
    private Waypoint startWaypoint, endWaypoint;

    private Dictionary<Vector2Int, Waypoint> gridOfWorld = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private List<Waypoint> pathFoundUsingBFS = new List<Waypoint>();
    private bool isPathFindRunning = false;
    private Waypoint searchCenter;

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        StartAndEndWaypointColor();
        isPathFindRunning = true;
        BreadthFirstSearch();
        TracePath();
        return pathFoundUsingBFS;
    }

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    private void LoadBlocks()
    {
        Waypoint[] waypointsInWorld = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypointTemporary in waypointsInWorld)
        {
            bool containsWaypoint = gridOfWorld.ContainsKey(waypointTemporary.GetGridPosition());
            if (containsWaypoint)
            {
                Debug.LogWarning("Trying to add duplicate " + waypointTemporary);
            }
            else
            {
                gridOfWorld.Add(waypointTemporary.GetGridPosition(), waypointTemporary);
                waypointTemporary.SetTopColor(Color.white);
            }
        }
        //Debug.Log("Loaded " + gridOfWorld.Count + " blocks.");
    }

    private void StartAndEndWaypointColor()
    {
        startWaypoint.SetTopColor(Color.red);
        endWaypoint.SetTopColor(Color.green);
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0 && isPathFindRunning)
        {
            searchCenter = queue.Dequeue();
            StopIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void TracePath()
    {
        Waypoint tempWaypoint = endWaypoint;
        while(tempWaypoint != startWaypoint)
        {
            pathFoundUsingBFS.Add(tempWaypoint);
            tempWaypoint = tempWaypoint.exploredFrom;
        }
        pathFoundUsingBFS.Add(startWaypoint);
        pathFoundUsingBFS.Reverse();
        
    }

    private void StopIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isPathFindRunning = false;
        }   
    }

    // A B G C H E D L F M I K Z
    private void ExploreNeighbours()
    {
        if (!isPathFindRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPosition() + direction; 
            if(gridOfWorld.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = gridOfWorld[neighbourCoordinates];
        if (!neighbour.isExplored && !queue.Contains(neighbour))
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }
}
