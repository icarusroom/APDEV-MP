using UnityEngine;
using UnityEngine.UI;

public class PlayerClass : MonoBehaviour
{
    public Text classNameText;
    public Text strengthText;
    public Text dexterityText;
    public Text constitutionText;
    public Text intelligenceText;
    public Text wisdomText;
    public Text charismaText;

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
        strengthText.text = "Strength: " + strength;
        dexterityText.text = "Dexterity: " + dexterity;
        constitutionText.text = "Constitution: " + constitution;
        intelligenceText.text = "Intelligence: " + intelligence;
        wisdomText.text = "Wisdom: " + wisdom;
        charismaText.text = "Charisma: " + charisma;
    }
}
