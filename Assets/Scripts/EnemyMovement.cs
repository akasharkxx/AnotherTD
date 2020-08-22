using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField][Range(0.1f, 1f)]
    private float movementSpeed = 1f;

    private void Start()
    {
        PathFinder pathFinderForThisEnemy = FindObjectOfType<PathFinder>();
        List<Waypoint> pathForThisEnemy = pathFinderForThisEnemy.GetPath();
        StartCoroutine(FollowPath(pathForThisEnemy));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        Debug.Log("Starting patrol..");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            Debug.Log("Visiting: " + waypoint.name);
            yield return new WaitForSeconds(movementSpeed);
        }
        Debug.Log("Ending patrol");
    }
}
