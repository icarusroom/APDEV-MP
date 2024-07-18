using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject Player;

    public bool swiped;
    private bool playerInTrigger;

    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
            player = other.gameObject;
            TryTeleport();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    public void TryTeleport()
    {
        if (playerInTrigger && swiped)
        {
            player.transform.position = spawnPoint.position;
            swiped = false;
            playerInTrigger = false; 
        }
        else
        {
            swiped = false;
        }
    }
}
