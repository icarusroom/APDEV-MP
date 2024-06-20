using UnityEngine;

[System.Serializable]
public class ClassStats
{
    public string className;
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int charisma;

    public ClassStats(string className, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        this.className = className;
        this.strength = strength;
        this.dexterity = dexterity;
        this.constitution = constitution;
        this.intelligence = intelligence;
        this.wisdom = wisdom;
        this.charisma = charisma;
    }
}
