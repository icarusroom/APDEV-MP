using UnityEngine;
using TMPro;

public class PlayerClass : MonoBehaviour
{
    public TextMeshProUGUI classNameText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI dexterityText;
    public TextMeshProUGUI constitutionText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI wisdomText;
    public TextMeshProUGUI charismaText;

    private void Start()
    {
        DisplayPlayerStats();
    }

    private void DisplayPlayerStats()
    {
        string className = PlayerPrefs.GetString("PlayerClassName", "Unknown");
        int strength = PlayerPrefs.GetInt("PlayerStrength", 0);
        int dexterity = PlayerPrefs.GetInt("PlayerDexterity", 0);
        int constitution = PlayerPrefs.GetInt("PlayerConstitution", 0);
        int intelligence = PlayerPrefs.GetInt("PlayerIntelligence", 0);
        int wisdom = PlayerPrefs.GetInt("PlayerWisdom", 0);
        int charisma = PlayerPrefs.GetInt("PlayerCharisma", 0);

        classNameText.text = "Class: " + className;
        strengthText.text = "STR: " + strength;
        dexterityText.text = "DEX: " + dexterity;
        constitutionText.text = "CON: " + constitution;
        intelligenceText.text = "INT: " + intelligence;
        wisdomText.text = "WIS: " + wisdom;
        charismaText.text = "CHA: " + charisma;
    }
}
