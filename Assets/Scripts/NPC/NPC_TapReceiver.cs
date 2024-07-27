using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class NPC_TapReceiver : MonoBehaviour , ITappable
{
    [Header("Dialogue Stats Parameters")]
    [SerializeField]
    private string _op1StatType;

    [SerializeField]
    private int _op1StatValue;

    [SerializeField]
    private string _op2StatType;

    [SerializeField]
    private int _op2StatValue;

    [Header("Dialogue Text Parameters")]
    [SerializeField]
    private string _dialogueHeader;

    [SerializeField]
    private string _op1Description;

    [SerializeField]
    private string _op2Description;

    [SerializeField]
    private string _op1Text;

    [SerializeField]
    private string _op2Text;

    [Header("Mission Parameters")]
    [SerializeField]
    private int _questType; 
    /*
    QuestType 0 = MainQuest
    QuestType 1 = SubQuest_1
    QuestType 2 = SubQuest_2
     */

    [SerializeField]
    private int _questPart; 

    [SerializeField]
    private int _NPCType;
    // Type 0 = 4 dialogue options, Type 1 = 1 dialogue options (success or fail only)

    private bool _inRange;

    public bool _isInteractable = true;
    public bool _isOption1Picked = false;
    public bool _isOption2Picked = false;

    public bool _adShown = false;
    private bool CheckPlayerProgress()
    {
        if(this._questType == 0)
        {
            if(this._questPart == PlayerProgress.MainQuestProgress)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if(this._questType == 1)
        {
            if (this._questPart == PlayerProgress.SubQuest_1Progress)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if(this._questType == 2)
        {
            if (this._questPart == PlayerProgress.SubQuest_2Progress)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }
    public void OnTap(TapEventArgs args)
    {
        if (this._inRange && this.CheckPlayerProgress())
        {
            DialogueStats.ActiveNPC = this;
            DialogueStats.Option1 = this._op1StatValue;
            DialogueStats.Option2 = this._op2StatValue;

            DialogueStats.Op1Type = this._op1StatType;
            DialogueStats.Op2Type = this._op2StatType;

            DialogueStats.NpcType = this._NPCType;

            DialogueStats.DialogueHeader = this._dialogueHeader;

            DialogueStats.Op1Description = this._op1Description;
            DialogueStats.Op2Description = this._op2Description;

            DialogueStats.Op1Text = this._op1Text;
            DialogueStats.Op2Text = this._op2Text;

            EventBroadcaster.Instance.PostEvent(EventNames.NPC_Dialogue_Events.ON_NPC_TAPPED);
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
