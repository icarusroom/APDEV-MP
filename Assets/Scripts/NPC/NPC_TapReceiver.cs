using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class NPC_TapReceiver : MonoBehaviour , ITappable
{
    [SerializeField]
    private int _option1;

    [SerializeField]
    private int _option2;

    [SerializeField]
    private string _op1Type;

    [SerializeField]
    private string _op2Type;

    [SerializeField]
    private string _op1Text;

    [SerializeField]
    private string _op2Text;

    [SerializeField]
    private GameObject _NPC;

    private bool _inRange;
    public void OnTap(TapEventArgs args)
    {
        if(this._inRange)
        {
            DialogueStats.Option1 = this._option1;
            DialogueStats.Option2 = this._option2;
            DialogueStats.Op1Type = this._op1Type;
            DialogueStats.Op2Type = this._op2Type;
            DialogueStats.Op1Text = this._op1Text;
            DialogueStats.Op2Text = this._op2Text;
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
