using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MarketUIDocument : MonoBehaviour
{
    [SerializeField] MarketManager marketManager;
    private VisualElement _root;
    private VisualElement _dialogueBox;
    private Button _option1;
    private Button _option2;
    private Button _option3;
    private Button _option4;

    private void Start()
    {
        this._root = GetComponent<UIDocument>().rootVisualElement;
        this._dialogueBox = this._root.Q<VisualElement>("DialogueBoxContainer");
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
        marketManager.OnDiceButtonClicked("DiceRoll");

        int PlayerSTR = PlayerPrefs.GetInt("PlayerStrength", 0);
        int Dialogue1STR = 10;
        int diceBonus;

        if (PlayerSTR >= Dialogue1STR) {
            if (PlayerSTR > 10) {
                diceBonus = PlayerSTR - 10;
            }
            else{ 
                diceBonus = 0; 
            }

            int diceRoll = DiceRollProperties.DiceRollResult;

            if (((diceRoll + diceBonus) >= Dialogue1STR) || DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED) {
                //succeed
                Debug.Log("[Option 1] : Success");
            }
            else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_FAIL) {
                //fail
                Debug.Log("[Option 1] : Failed");
            }
            else {
                //fail
                Debug.Log("[Option 1] : Failed");
            }
        }

        else {
            int diceRoll = DiceRollProperties.DiceRollResult;

            if ((diceRoll >= Dialogue1STR + 1) || DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED) {
                //success
                Debug.Log("[Option 1] : Success");
            }
            else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_FAIL) {
                //fail
                Debug.Log("[Option 1] : Failed");
            }
            else {
                //fail
                Debug.Log("[Option 1] : Failed");
            }
        }
    }

    private void OnOption2Clicked()
    {
        marketManager.OnDiceButtonClicked("DiceRoll");

        int PlayerCHA = PlayerPrefs.GetInt("PlayerCharisma", 0);
        int Dialogue1CHA = 14;
        int diceBonus;

        if (PlayerCHA >= Dialogue1CHA)
        {
            if (PlayerCHA > 14)
            {
                diceBonus = PlayerCHA - 14;
            }
            else
            {
                diceBonus = 0;
            }

            int diceRoll = DiceRollProperties.DiceRollResult;

            if (((diceRoll + diceBonus) >= Dialogue1CHA) || DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
            {
                //succeed
                Debug.Log("[Option 2] : Success");
            }
            else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_FAIL)
            {
                //fail
                Debug.Log("[Option 2] : Failed");
            }
            else
            {
                //fail
                Debug.Log("[Option 2] : Failed");
            }
        }

        else
        {
            int diceRoll = DiceRollProperties.DiceRollResult;

            if ((diceRoll >= Dialogue1CHA + 1) || DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
            {
                //success
                Debug.Log("[Option 1] : Success");
            }
            else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_FAIL)
            {
                //fail
                Debug.Log("[Option 1] : Failed");
            }
            else
            {
                //fail
                Debug.Log("[Option 1] : Failed");
            }
        }
    }

    private void OnOption3Clicked()
    {
        Debug.Log("Option_3 Clicked");
    }

    private void OnOption4Clicked()
    {
        this.HideDialogueBox();
    }

    private void HideDialogueBox()
    {
        Debug.Log("HideDialogueBox: Hiding the dialogue box");
        this._dialogueBox.style.visibility = Visibility.Hidden;
    }

    private void ShowDialogueBox()
    {
        Debug.Log("ShowDialogueBox: Showing the dialogue box");
        this._dialogueBox.style.visibility = Visibility.Visible;
    }

    public void OnDiceSceneClosed()
    {
        HideDialogueBox();
    }

}
