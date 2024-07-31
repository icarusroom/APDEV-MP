using UnityEngine;

public class EnemyStats : CharacterStats
{
    public string className;
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int charisma;
    private void Start()
    {
        className = "Soldier";
        strength = 10;
        dexterity = 10;
        constitution = 10;
        intelligence = 10;
        wisdom = 10;
        charisma = 10;
    }
}
