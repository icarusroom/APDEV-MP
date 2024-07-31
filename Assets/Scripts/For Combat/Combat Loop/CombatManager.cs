using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PlayerStats player;
    public EnemyStats enemy;
    public BuiltInDice builtinDice;
    public CombatUIManager combatUIManager;

    private void Start()
    {
        StartCoroutine(CombatRoutine());
    }

    private IEnumerator CombatRoutine()
    {
        while (player.currentHealth > 0 && enemy.currentHealth > 0)
        {
            yield return PlayerTurn();
            if (enemy.currentHealth <= 0) break;

            yield return EnemyTurn();
        }

        EndCombat();
    }

    private IEnumerator PlayerTurn()
    {
        yield return null;  
    }

    public void PlayerAttack()
    {
        StartCoroutine(Attack(player, enemy));
    }

    public void PlayerHeal()
    {
        int healAmount = BuiltInDice.Roll(1, 12) + player.wisdom;
        player.Heal(healAmount);
    }

    public void PlayerMove()
    {
        // Implement movement logic
        Debug.Log("Player moved.");
    }

    private IEnumerator EnemyTurn()
    {
        // Example enemy action
        yield return Attack(enemy, player);
    }

    private IEnumerator Attack(CharacterStats attacker, CharacterStats defender)
    {
        int damage = BuiltInDice.CalculateDamage(attacker.strength);
        defender.TakeDamage(damage);
        yield return null;
    }

    private void EndCombat()
    {
        if (player.currentHealth <= 0)
        {
            Debug.Log("Player defeated!");
        }
        else if (enemy.currentHealth <= 0)
        {
            Debug.Log("Enemy defeated!");
        }
    }
}
