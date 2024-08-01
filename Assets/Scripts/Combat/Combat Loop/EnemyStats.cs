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
}
