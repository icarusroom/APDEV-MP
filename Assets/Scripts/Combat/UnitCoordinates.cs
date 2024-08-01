using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCoordinates : MonoBehaviour
{
    public static UnitCoordinates Instance { get; private set; }

    public Vector2Int unitCoord;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            // Destroy this instance if it's not the singleton instance
            Destroy(gameObject);
        }
        else
        {
            // Set this instance as the singleton instance
            Instance = this;
            // Optionally, make this object persist across scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            Tile tile = other.GetComponent<Tile>();
            if (tile != null)
            {
                unitCoord = tile.cords;
                Debug.Log($"Unit entered Tile with coordinates: {unitCoord}");
            }
            else
            {
                Debug.LogError("Tile component not found on the collided object.");
            }
        }
    }

    public Vector2Int GetUnitCoord()
    {
        return unitCoord;
    }
}
