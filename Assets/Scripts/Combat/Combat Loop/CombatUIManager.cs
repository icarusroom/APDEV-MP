using UnityEngine;
using UnityEngine.UI;

public class CombatUIManager : MonoBehaviour
{
    public CombatManager combatManager;

    public Button attackButton;
    public Button healButton;
    public Button moveButton;

    private void Start()
    {
        attackButton.onClick.AddListener(OnAttackButton);
        healButton.onClick.AddListener(OnHealButton);
        moveButton.onClick.AddListener(OnMoveButton);
    }

    private void OnAttackButton()
    {
        combatManager.PlayerAttack();
    }

    private void OnHealButton()
    {
        combatManager.PlayerHeal();
    }

    private void OnMoveButton()
    {
        combatManager.PlayerMove();
    }
}
