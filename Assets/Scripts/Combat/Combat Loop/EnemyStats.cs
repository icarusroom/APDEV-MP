using UnityEngine;

public class EnemyStats : CharacterStats
{
    public string className;
    public int enemyStrength;
    public int enemyDexterity;
    public int enemyConstitution;
    public int enemyIntelligence;
    public int enemyWisdom;
    public int enemyCharisma;

    private void Start()
    {
        className = "Soldier";
        enemyStrength = 10;
        enemyDexterity = 10;
        enemyConstitution = 10;
        enemyIntelligence = 10;
        enemyWisdom = 10;
        enemyCharisma = 10;
    }

    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unit"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Unit"))
        {
            playerInRange = false;
        }
    }

    public bool IsPlayerInRange()
    {
        return playerInRange;
    }
}
