using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance;

    public ClassStats classStats; 

    public int CurrentHealth { get; private set; }
    public int MaxHealth => classStats.constitution * 10;
    public int Strength => classStats.strength;
    public int Dexterity => classStats.dexterity;
    public int Constitution => classStats.constitution;
    public int Intelligence => classStats.intelligence;
    public int Wisdom => classStats.wisdom;
    public int Charisma => classStats.charisma;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeStats();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeStats()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
}
