using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[ExecuteAlways]
public class Labeller : MonoBehaviour
{

    TextMeshPro Label;
    public Vector2Int cords = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        Label = GetComponentInChildren<TextMeshPro>();

        DisplayCords();
    }

    private void Update()
    {
        DisplayCords();
        transform.name = cords.ToString();
    }
    private void DisplayCords()
    {
        if (!gridManager) { return; }
        cords.x = Mathf.RoundToInt(transform.position.x / gridManager.UnityGridSize);
        cords.y = Mathf.RoundToInt(transform.position.z / gridManager.UnityGridSize);

        Label.text = $"{cords.x},{cords.y}";
    }
}
