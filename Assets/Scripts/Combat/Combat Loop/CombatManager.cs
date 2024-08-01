using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PlayerStats player;
    public EnemyStats enemy;
    public InternalDice internalDice;
    public CombatUIManager combatUIManager;
    public GridManager gridManager;
    public Pathfinding pathfinding;
    [SerializeField] private MarketManager marketManager;

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
        // Wait for player input via UI
        yield return new WaitUntil(() => combatUIManager.ActionSelected);

        // Perform the selected action
        if (combatUIManager.SelectedAction == CombatUIManager.ActionType.Attack)
        {
            PlayerAttack();
        }
        else if (combatUIManager.SelectedAction == CombatUIManager.ActionType.Heal)
        {
            PlayerHeal();
        }

        // Reset action state
        combatUIManager.ResetActionState();
    }

    public void PlayerAttack()
    {
        if (player.IsEnemyInRange()) // Check if the enemy is in range using the trigger collider
        {
            // Roll the dice
            internalDice.OnInternalDiceRolled();
            int damage = internalDice.diceResult + player.strength;

            // Deal damage to the enemy
            enemy.TakeDamage(damage);

            // Display the dice roll result in the UI
            combatUIManager.UpdateDiceRollResult(internalDice.diceResult);

            // Continue to the enemy's turn
            StartCoroutine(EnemyTurn());
        }
        else
        {
            Debug.Log("Enemy is out of melee range.");
        }
    }

    public void PlayerHeal()
    {
        // Roll the dice
        internalDice.OnInternalDiceRolled();
        int healAmount = internalDice.diceResult + player.wisdom;

        // Heal the player
        player.Heal(healAmount);

        // Display the dice roll result in the UI
        combatUIManager.UpdateDiceRollResult(internalDice.diceResult);

        // Continue to the enemy's turn
        StartCoroutine(EnemyTurn());
    }

    public void PlayerMove(Vector2Int targetCords)
    {
        Vector2Int playerCoords = gridManager.GetCoordinatesFromPosition(player.transform.position);
        List<Node> path = pathfinding.GetNewPath(playerCoords, targetCords);
        StartCoroutine(MoveAlongPath(path));
        combatUIManager.ResetActionState(); // Reset action state
        StartCoroutine(EnemyTurn());
    }

    private IEnumerator MoveAlongPath(List<Node> path)
    {
        foreach (Node node in path)
        {
            Vector3 targetPosition = gridManager.GetPositionFromCoordinates(node.cords);
            player.transform.position = targetPosition; // Simplified movement logic
            yield return new WaitForSeconds(0.5f); // Adjust as needed for smoothness
        }
    }

    private IEnumerator EnemyTurn()
    {
        if (enemy.IsPlayerInRange()) // Check if the player is in range using the trigger collider
        {
            // Roll the dice
            internalDice.OnInternalDiceRolled();
            int damage = internalDice.diceResult + enemy.strength;

            // Deal damage to the player
            player.TakeDamage(damage);

            // Display the dice roll result in the UI
            combatUIManager.UpdateDiceRollResult(internalDice.diceResult);
        }
        else
        {
            Debug.Log("Player is out of enemy's range.");
        }
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

    ///////////////////////// DEV BUTTONS //////////////////////////

    public void OnWinButton()
    {
        CombatProperties.CombatResult = true;
        CloseCombat();
    }

    public void OnLoseButton()
    {
        CombatProperties.CombatResult = false;
        CloseCombat();
    }

    private void CloseCombat()
    {
        if (marketManager != null)
        {
            marketManager.OnCombatClosed();
        }
    }
}
