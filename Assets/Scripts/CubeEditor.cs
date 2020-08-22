using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypointComponentCube;

    private void Awake()
    {
        waypointComponentCube = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapCubeToGrid(); 
        UpdateLabelOnCube();
    }

    private void SnapCubeToGrid()
    {
        int gridSize = waypointComponentCube.GetGridSize();
        transform.position = new Vector3(
                    waypointComponentCube.GetGridPosition().x * gridSize,
                    0f,
                    waypointComponentCube.GetGridPosition().y * gridSize
                );
    }

    private void UpdateLabelOnCube()
    {
        int gridSize = waypointComponentCube.GetGridSize();
        string cubeCoordinate = waypointComponentCube.GetGridPosition().x + 
                                "," + 
                                waypointComponentCube.GetGridPosition().y;
        TextMesh cubeCoordinateLabel = GetComponentInChildren<TextMesh>();
        cubeCoordinateLabel.text = cubeCoordinate;
        gameObject.name = cubeCoordinate;
    }
}
