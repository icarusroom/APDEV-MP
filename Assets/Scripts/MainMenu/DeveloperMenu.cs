using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeveloperMenu : MonoBehaviour
{
    [SerializeField] MenuUiDocument menu;
    [SerializeField] TMP_Text diceRollText;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject DeveloperPanel;

    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
        diceRollText.text = "Normal";
    }

    public void OnBackButtonClicked()
    {
        DeveloperPanel.SetActive(false);
        menu.DisplayMenu();
    }

    public void OnDiceRollClicked()
    {
        if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_NORMAL)
        {
            DeveloperProperties.DiceRoll = EDiceRoll.DICE_ROLL_SUCCEED;
            diceRollText.text = "Always Succeed";
        }
        else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
        {
            DeveloperProperties.DiceRoll = EDiceRoll.DICE_ROLL_FAIL;
            diceRollText.text = "Always Fail";
        }
        else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_FAIL)
        {
            DeveloperProperties.DiceRoll = EDiceRoll.DICE_ROLL_NORMAL;
            diceRollText.text = "Normal";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
