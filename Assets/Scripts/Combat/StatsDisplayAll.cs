using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsDisplayAll : MonoBehaviour
{
    public TextMeshProUGUI classNameText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI dexterityText;
    public TextMeshProUGUI constitutionText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI wisdomText;
    public TextMeshProUGUI charismaText;

    public TextMeshProUGUI classNameText2;
    public TextMeshProUGUI strengthText2;
    public TextMeshProUGUI dexterityText2;
    public TextMeshProUGUI constitutionText2;
    public TextMeshProUGUI intelligenceText2;
    public TextMeshProUGUI wisdomText2;
    public TextMeshProUGUI charismaText2;

    public TextMeshProUGUI classNameText3;
    public TextMeshProUGUI strengthText3;
    public TextMeshProUGUI dexterityText3;
    public TextMeshProUGUI constitutionText3;
    public TextMeshProUGUI intelligenceText3;
    public TextMeshProUGUI wisdomText3;
    public TextMeshProUGUI charismaText3;

    public TextMeshProUGUI classNameText4;
    public TextMeshProUGUI strengthText4;
    public TextMeshProUGUI dexterityText4;
    public TextMeshProUGUI constitutionText4;
    public TextMeshProUGUI intelligenceText4;
    public TextMeshProUGUI wisdomText4;
    public TextMeshProUGUI charismaText4;

    void Start()
    {
        DisplayAllStats();
    }

    private void DisplayAllStats()
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








        string className2 = PlayerPrefs.GetString("Party1ClassName", "Unknown");
        int strength2 = PlayerPrefs.GetInt("Party1Strength", 0);
        int dexterity2 = PlayerPrefs.GetInt("Party1Dexterity", 0);
        int constitution2 = PlayerPrefs.GetInt("Party1Constitution", 0);
        int intelligence2 = PlayerPrefs.GetInt("Party1Intelligence", 0);
        int wisdom2 = PlayerPrefs.GetInt("Party1Wisdom", 0);
        int charisma2 = PlayerPrefs.GetInt("Party1Charisma", 0);

        classNameText2.text = "Class: " + className2;
        strengthText2.text = "STR: " + strength2;
        dexterityText2.text = "DEX: " + dexterity2;
        constitutionText2.text = "CON: " + constitution2;
        intelligenceText2.text = "INT: " + intelligence2;
        wisdomText2.text = "WIS: " + wisdom2;
        charismaText2.text = "CHA: " + charisma2;

        string className3 = PlayerPrefs.GetString("Party2ClassName", "Unknown");
        int strength3 = PlayerPrefs.GetInt("Party2Strength", 0);
        int dexterity3 = PlayerPrefs.GetInt("Party2Dexterity", 0);
        int constitution3 = PlayerPrefs.GetInt("Party2Constitution", 0);
        int intelligence3 = PlayerPrefs.GetInt("Party2Intelligence", 0);
        int wisdom3 = PlayerPrefs.GetInt("Party2Wisdom", 0);
        int charisma3 = PlayerPrefs.GetInt("Party2Charisma", 0);

        classNameText3.text = "Class: " + className3;
        strengthText3.text = "STR: " + strength3;
        dexterityText3.text = "DEX: " + dexterity3;
        constitutionText3.text = "CON: " + constitution3;
        intelligenceText3.text = "INT: " + intelligence3;
        wisdomText3.text = "WIS: " + wisdom3;
        charismaText3.text = "CHA: " + charisma3;

        string className4 = PlayerPrefs.GetString("Party3ClassName", "Unknown");
        int strength4 = PlayerPrefs.GetInt("Party3Strength", 0);
        int dexterity4 = PlayerPrefs.GetInt("Party3Dexterity", 0);
        int constitution4 = PlayerPrefs.GetInt("Party3Constitution", 0);
        int intelligence4 = PlayerPrefs.GetInt("Party3Intelligence", 0);
        int wisdom4 = PlayerPrefs.GetInt("Party3Wisdom", 0);
        int charisma4 = PlayerPrefs.GetInt("Party3Charisma", 0);

        classNameText4.text = "Class: " + className4;
        strengthText4.text = "STR: " + strength4;
        dexterityText4.text = "DEX: " + dexterity4;
        constitutionText4.text = "CON: " + constitution4;
        intelligenceText4.text = "INT: " + intelligence4;
        wisdomText4.text = "WIS: " + wisdom4;
        charismaText4.text = "CHA: " + charisma4;
    }
}
