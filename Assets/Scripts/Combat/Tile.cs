using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public bool blocked;
    [SerializeField] public Vector2Int cords; 

    GridManager gridManager;

    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();

        if (blocked)
        {
            gridManager.BlockNode(cords);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Unit"))
        {
            if (!blocked)
            {
                blocked = true;
                gridManager.BlockNode(cords);
                Debug.Log($"Tile {cords} is now blocked.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Unit"))
        {
            if (blocked)
            {
                blocked = false;
                gridManager.UnblockNode(cords);
                Debug.Log($"Tile {cords} is now unblocked.");
            }
        }
    }
}
