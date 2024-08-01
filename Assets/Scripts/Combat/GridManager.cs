using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [SerializeField] int unityGridSize;
    public int UnityGridSize { get { return unityGridSize; } }

    public Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    [SerializeField] List<GameObject> tiles = new List<GameObject>();

    private void Awake()
    {
        CreateGrid();
        InitializeTiles();
        PrintGridContents();  // Print grid contents after creation
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].walkable = false;
        }
    }

    public void UnblockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].walkable = true;
        }
    }

    public void ResetNodes()
    {
        foreach (KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.connectTo = null;
            entry.Value.explored = false;
            entry.Value.path = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int
        {
            x = Mathf.RoundToInt(position.x / unityGridSize),
            y = Mathf.RoundToInt(position.z / unityGridSize)
        };

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        foreach (GameObject tile in tiles)
        {
            Tile tileComponent = tile.GetComponent<Tile>();
            if (tileComponent != null && tileComponent.cords == coordinates)
            {
                Vector3 tilePosition = tile.transform.position;
                return tilePosition;
            }
        }

        Debug.LogError($"No tile found with coordinates ({coordinates})");
        return Vector3.zero;
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int cords = new Vector2Int(x, y);
                grid.Add(cords, new Node(cords, true));
            }
        }
    }

    private void InitializeTiles()
    {
        foreach (GameObject tile in tiles)
        {
            Tile tileComponent = tile.GetComponent<Tile>();
            if (tileComponent != null)
            {
                if (tileComponent.blocked)
                {
                    BlockNode(tileComponent.cords);
                }
            }
        }
    }

    public void PrintGridContents()
    {
        foreach (var entry in grid)
        {
            Vector2Int coordinates = entry.Key;
            Node node = entry.Value;
            Debug.Log($"Coordinates: {coordinates} - Walkable: {node.walkable}");
        }
    }
}
