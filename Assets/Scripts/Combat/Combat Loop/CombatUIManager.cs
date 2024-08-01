using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIManager : MonoBehaviour
{
    public Button attackButton;
    public Button healButton;
    public TMP_Text diceRollResultText;
    public bool ActionSelected { get; private set; }
    public enum ActionType { Attack, Heal }
    public ActionType SelectedAction { get; private set; }

    void Start()
    {
        attackButton.onClick.AddListener(OnAttackButton);
        healButton.onClick.AddListener(OnHealButton);
    }

    private void OnAttackButton()
    {
        SelectedAction = ActionType.Attack;
        ActionSelected = true;
    }

    private void OnHealButton()
    {
        SelectedAction = ActionType.Heal;
        ActionSelected = true;
    }

    public void UpdateDiceRollResult(int result)
    {
        diceRollResultText.text = "Dice Roll: " + result;
    }

    public void ResetActionState()
    {
        ActionSelected = false;
    }
}
