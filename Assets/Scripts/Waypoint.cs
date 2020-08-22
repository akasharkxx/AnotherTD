using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int GRID_SIZE = 10;
    Vector2Int gridPositionInWorld;

    [SerializeField]
    private Color exploredColor;
    
    // Public is ok here as is data class 
    [HideInInspector]
    public bool isExplored = false;
    public Waypoint exploredFrom;

    private void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
        }
    }

    public int GetGridSize()
    {
        return GRID_SIZE;
    }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / GRID_SIZE),
            Mathf.RoundToInt(transform.position.z / GRID_SIZE)
        );
    }

    public void SetTopColor(Color topColor)
    {
        MeshRenderer topMeshRendererOfCube = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRendererOfCube.material.color = topColor;
    }
}
