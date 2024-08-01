using UnityEngine;

public class BuiltInDice : MonoBehaviour
{
    public static BuiltInDice Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Roll(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    public int CalculateDamage(int strength)
    {
        int roll = Roll(1, 12);
        int baseDamage = roll + strength; 
        return baseDamage;
    }

    public bool IsCriticalHit(int criticalChance)
    {
        return Roll(1, 100) <= criticalChance;
    }

    public bool IsHit(int hitChance)
    {
        return Roll(1, 100) <= hitChance;
    }
}
