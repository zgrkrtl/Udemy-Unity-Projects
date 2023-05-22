using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [Tooltip("unity editor snap settings")]
    [SerializeField] int unityGridSize = 10;

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    public int UnityGridSize { get { return unityGridSize; } }
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    void Awake()
    {
        createGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates)) { return grid[coordinates]; }
        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {

        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int getCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt((position.x) / (unityGridSize));
        coordinates.y = Mathf.RoundToInt((position.z) / (unityGridSize));

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;
        return position;
    }
    void createGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));

            }
        }
    }
}
