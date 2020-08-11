using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> path;

    private void Start()
    {
        //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        Debug.Log("Starting patrol..");
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            Debug.Log("Visiting: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Ending patrol");
    }
}
