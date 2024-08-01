using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    Transform selectedUnit;
    bool unitSelected = false;
    List<Node> path = new List<Node>();
    GridManager gridManager;
    Pathfinding pathFinder;

    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<Pathfinding>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Tile"))
                {
                    if (unitSelected)
                    {
                        Tile tile = hit.transform.GetComponent<Tile>();
                        Vector2Int targetCords = tile.cords;

                        // Check if the selected tile is walkable
                        if (gridManager.GetNode(targetCords).walkable)
                        {
                            Vector2Int startCords = UnitCoordinates.Instance.GetUnitCoord(); // Use unitCoordinates to get the current tile
                            Debug.Log($"Clicked tile coordinates: {targetCords}");

                            pathFinder.SetNewDestination(startCords, targetCords);
                            RecalculatePath(true);
                            unitSelected = false;
                        }
                        else
                        {
                            Debug.Log("Selected tile is not walkable.");
                        }
                    }
                }
                else if (hit.transform.CompareTag("Unit"))
                {
                    selectedUnit = hit.transform;
                    unitSelected = true;
                }
            }
        }
    }


    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates;
        if (resetPath)
        {
            coordinates = pathFinder.StartCords;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathFinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        if (path.Count == 0) yield break;

        foreach (Node node in path)
        {
            Vector3 targetPosition = gridManager.GetPositionFromCoordinates(node.cords);
            targetPosition.y = selectedUnit.position.y; 
            Vector3 startPosition = selectedUnit.position;

            float journeyLength = Vector3.Distance(startPosition, targetPosition);
            float startTime = Time.time;

            while (Vector3.Distance(selectedUnit.position, targetPosition) > 1f)
            {
                float distanceCovered = (Time.time - startTime) * 5;
                float fractionOfJourney = distanceCovered / journeyLength;
                selectedUnit.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
                yield return null;
            }

            selectedUnit.position = targetPosition;
        }
    }
}
