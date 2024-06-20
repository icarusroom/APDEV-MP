using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class NPC_TapReceiver : MonoBehaviour , ITappable
{
    [SerializeField]
    private int _NPCType;

    [SerializeField]
    private GameObject _NPC;

    private bool _inRange;
    public void OnTap(TapEventArgs args)
    {
        if(this._inRange)
        {
            EventBroadcaster.Instance.PostEvent(EventNames.NPC_Dialogue_Events.ON_NPC_TAPPED);
            Debug.Log("NPC Tapped");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            _inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            EventBroadcaster.Instance.PostEvent(EventNames.NPC_Dialogue_Events.ON_NPC_NOT_IN_RANGE);
            Debug.Log("Player out of range");
            _inRange = false;
        }
    }
}
