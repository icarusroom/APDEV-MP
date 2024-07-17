using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class NPC_TapReceiver : MonoBehaviour , ITappable
{
    [Header("Dialogue Stats Parameters")]
    [SerializeField]
    private int _option1;

    [SerializeField]
    private int _option2;

    [SerializeField]
    private string _op1Type;

    [SerializeField]
    private string _op2Type;

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
    private int _NPCType; // Type 0 = 4 dialogue options, Type 1 = 2 dialogue options (success or fail only)

    private bool _inRange;

    private bool CheckPlayerProgress()
    {
        if(this._questType == 0)
        {
            if(this._questPart == PlayerProgress.MainQuestProgress)
            {
                Debug.Log("Main Quest Part 1");
                return true;
            }
            else
            {
                Debug.Log("Progress to interact");
            }
        }

        if(this._questType == 1)
        {
            if (this._questPart == PlayerProgress.SubQuest_1Progress)
            {
                Debug.Log("Sub Quest 1 Part 1");
                return true;
            }
            else
            {
                Debug.Log("Progress to interact");
            }
        }

        if(this._questType == 2)
        {
            if (this._questPart == PlayerProgress.SubQuest_2Progress)
            {
                Debug.Log("Sub Quest 2 Part 1");
                return true;
            }
            else
            {
                Debug.Log("Progress to interact");
            }
        }

        return false;
    }
    public void OnTap(TapEventArgs args)
    {
        if(this._inRange && this.CheckPlayerProgress())
        {
            DialogueStats.Option1 = this._option1;
            DialogueStats.Option2 = this._option2;

            DialogueStats.Op1Type = this._op1Type;
            DialogueStats.Op2Type = this._op2Type;

            DialogueStats.DialogueHeader = this._dialogueHeader;

            DialogueStats.Op1Description = this._op1Description;
            DialogueStats.Op2Description = this._op2Description;

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
