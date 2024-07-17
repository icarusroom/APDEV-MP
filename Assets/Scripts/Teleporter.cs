using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject Player;

    public bool swiped;
    private bool playerInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
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
            Player.transform.position = spawnPoint.position;
            swiped = false;
            playerInTrigger = false; 
        }
        else
        {
            swiped = false;
        }
    }
}
