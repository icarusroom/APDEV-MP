using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MarketUIDocument : MonoBehaviour
{
    [SerializeField] MarketManager marketManager;
    [SerializeField] PlayerProgressManger progressManger;
    private VisualElement _root;
    private VisualElement _dialogueBox;
    private Label _dialogueHeader;
    private Button _option1;
    private Button _option2;
    private Button _option3;
    private Button _option4;

    private void Start()
    {
        this._root = GetComponent<UIDocument>().rootVisualElement;
        this._dialogueBox = this._root.Q<VisualElement>("DialogueBoxContainer");
        this._dialogueHeader = this._root.Q<Label>("DialogueHeader");
        this._option1 = this._root.Q<Button>("Option_1");
        this._option2 = this._root.Q<Button>("Option_2");
        this._option3 = this._root.Q<Button>("Option_3");
        this._option4 = this._root.Q<Button>("Option_4");

        this._option1.clicked += this.OnOption1Clicked;
        this._option2.clicked += this.OnOption2Clicked;
        this._option3.clicked += this.OnOption3Clicked;
        this._option4.clicked += this.OnOption4Clicked;

        this.HideDialogueBox();

        EventBroadcaster.Instance.AddObserver(EventNames.NPC_Dialogue_Events.ON_NPC_TAPPED, this.ShowDialogueBox);
        EventBroadcaster.Instance.AddObserver(EventNames.NPC_Dialogue_Events.ON_NPC_NOT_IN_RANGE, this.HideDialogueBox);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.NPC_Dialogue_Events.ON_NPC_TAPPED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.NPC_Dialogue_Events.ON_NPC_NOT_IN_RANGE);
    }
    private void OnOption1Clicked()
    {
        StartCoroutine(HandleOption1());
    }

    IEnumerator HandleOption1()
    {
        marketManager.OnDiceButtonClicked("DiceRoll");

        yield return new WaitUntil(() => MarketManager.Instance.IsDiceRolled);

        int PlayerStat = PlayerPrefs.GetInt(DialogueStats.Op1Type, 0);
        int diceBonus;
        int diceRoll = DiceRollProperties.DiceRollResult;

        if (PlayerStat >= DialogueStats.Option1)
        {
            if (PlayerStat > 10)
            {
                diceBonus = PlayerStat - 10;
            }

            else
            {
                diceBonus = 0;
            }

            if (((diceRoll + diceBonus) >= DialogueStats.Option1) || DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
            {
                this.DiceRollSuccessful(DialogueStats.QuestType); //Updates the player progress
                PlayerProgress.PositiveChoiceCounter++;
                Debug.Log("[Option 1] : Success");
            }

            else
            {
                if (DialogueStats.NpcType == 1)
                {
                    this.DiceRollSuccessful(DialogueStats.QuestType);
                    PlayerProgress.NegativeChoiceCounter++;
                }
                Debug.Log("[Option 1] : Failed");
            }
        }

        else
        {
            if ((diceRoll >= DialogueStats.Option1 + 1) || DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
            {
                this.DiceRollSuccessful(DialogueStats.QuestType); //Updates the player progress
                PlayerProgress.PositiveChoiceCounter++;
                Debug.Log("[Option 1] : Success");
            }

            else
            {
                if (DialogueStats.NpcType == 1)
                {
                    this.DiceRollSuccessful(DialogueStats.QuestType);
                    PlayerProgress.NegativeChoiceCounter++;
                }
                Debug.Log("[Option 1] : Failed");
            }
        }

        NPCManager.Instance.DisableDialogue(1); //This option is disabled after choosing it.
        MarketManager.Instance.IsDiceRolled = false;
    }

    private void OnOption2Clicked()
    {
        StartCoroutine(HandleOption2());
    }

    IEnumerator HandleOption2()
    {
        marketManager.OnDiceButtonClicked("DiceRoll");

        yield return new WaitUntil(() => MarketManager.Instance.IsDiceRolled);

        int PlayerStat = PlayerPrefs.GetInt(DialogueStats.Op2Type, 0);
        int diceBonus;
        int diceRoll = DiceRollProperties.DiceRollResult;

        if (PlayerStat >= DialogueStats.Option2)
        {
            if (PlayerStat > 10)
            {
                diceBonus = PlayerStat - 10;
            }
            else
            {
                diceBonus = 0;
            }

            if (((diceRoll + diceBonus) >= DialogueStats.Option2) || DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
            {
                this.DiceRollSuccessful(DialogueStats.QuestType); //Updates the player progress
                PlayerProgress.NegativeChoiceCounter++;
                Debug.Log("[Option 2] : Success");
            }

            else
            {
                //fail
                Debug.Log("[Option 2] : Failed");
            }
        }

        else
        {
            if ((diceRoll >= DialogueStats.Option2 + 1) || DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
            {
                this.DiceRollSuccessful(DialogueStats.QuestType); //Updates the player progress
                PlayerProgress.NegativeChoiceCounter++;
                Debug.Log("[Option 2] : Success");
            }

            else
            {
                Debug.Log("[Option 2] : Failed");
            }
        }

        NPCManager.Instance.DisableDialogue(2);
        MarketManager.Instance.IsDiceRolled = false;
    }

    private void OnOption3Clicked()
    {
        //Combat script
    }

    private void OnOption4Clicked()
    {
        this.HideDialogueBox();
    }

    public void HideDialogueBox()
    {
        this._dialogueBox.style.visibility = Visibility.Hidden;
        this._option1.style.visibility = Visibility.Hidden;
        this._option2.style.visibility = Visibility.Hidden;
        this._option3.style.visibility = Visibility.Hidden;
        this._option4.style.visibility = Visibility.Hidden;
    }

    private void ShowDialogueBox()
    {
        this._dialogueHeader.text = DialogueStats.DialogueHeader;
        this.UpdateDialogueOptions();
    }

    private void UpdateDialogueOptions()
    {
        this._option1.style.visibility = Visibility.Visible;
        this._option2.style.visibility = Visibility.Visible;
        this._option3.style.visibility = Visibility.Visible;
        this._option4.style.visibility = Visibility.Visible;

        if(DialogueStats.NpcType == 0)
        {
            this._option1.text = DialogueStats.Op1Description + "\n" + DialogueStats.Op1Text + " >= " + DialogueStats.Option1.ToString();
            this._option2.text = DialogueStats.Op2Description + "\n" + DialogueStats.Op2Text + " >= " + DialogueStats.Option2.ToString();
            this._option3.text = "Initiate Combat";
            this._option4.text = "Leave";
        }

        if (DialogueStats.NpcType == 1)
        {
            this._option1.text = DialogueStats.Op1Description + "\n" + DialogueStats.Op1Text + " >= " + DialogueStats.Option1.ToString();
            this._option2.style.visibility = Visibility.Hidden;
            this._option3.style.visibility = Visibility.Hidden;
            this._option4.text = "Leave";
        }

        if (!NPCManager.Instance.IsOptionAvailable(1))
        {
            this._option1.style.visibility = Visibility.Hidden;
        }

        if (!NPCManager.Instance.IsOptionAvailable(2))
        {
            this._option2.style.visibility = Visibility.Hidden;
        }
    }

    private void DiceRollSuccessful(int questType)
    {
        switch (questType)
        {
            case 0:
                PlayerProgressManger.Instance.MainQuestProgress();
                break;
            case 1:
                PlayerProgressManger.Instance.SubQuest_1Progress();
                break;
            case 2:
                PlayerProgressManger.Instance.SubQuest_2Progress();
                break;
        }
    }

    public void OnDiceSceneClosed()
    {
        HideDialogueBox();
    }
}
