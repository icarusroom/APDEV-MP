using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeReceiver : MonoBehaviour
{
    private Teleporter teleporter;

    void Start()
    {
        teleporter = GetComponent<Teleporter>();

        GestureManager.Instance.OnSwipe += this.OnSwipe;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnSwipe -= this.OnSwipe;
    }

    public void OnSwipe(object sender, SwipeEventArgs args)
    {
        teleporter.swiped = true;
        teleporter.TryTeleport();
        Debug.Log("TELEPORT TO BARRACKS");
    }
}
