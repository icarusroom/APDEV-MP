using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassSelection : MonoBehaviour
{
    public ClassStats warriorStats = new ClassStats("Warrior", 18, 12, 16, 10, 8, 14);
    public ClassStats mageStats = new ClassStats("Mage", 8, 12, 10, 18, 16, 10);
    public ClassStats rogueStats = new ClassStats("Rogue", 10, 18, 14, 12, 10, 16);
    public ClassStats clericStats = new ClassStats("Cleric", 14, 10, 14, 12, 18, 12);

    public void SelectWarrior()
    {
        SetPlayerClass(warriorStats);
        SetPartyClass(mageStats, rogueStats, clericStats);
        LoadMarketScene();
    }

    public void SelectMage()
    {
        SetPlayerClass(mageStats);
        SetPartyClass(warriorStats, rogueStats, clericStats);
        LoadMarketScene();
    }

    public void SelectRogue()
    {
        SetPlayerClass(rogueStats);
        SetPartyClass(mageStats, mageStats, clericStats);
        LoadMarketScene();
    }

    public void SelectCleric()
    {
        SetPlayerClass(clericStats);
        SetPartyClass(mageStats, rogueStats, rogueStats);
        LoadMarketScene();
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void SetPlayerClass(ClassStats classStats)
    {
        PlayerPrefs.SetString("PlayerClassName", classStats.className);
        PlayerPrefs.SetInt("PlayerStrength", classStats.strength);
        PlayerPrefs.SetInt("PlayerDexterity", classStats.dexterity);
        PlayerPrefs.SetInt("PlayerConstitution", classStats.constitution);
        PlayerPrefs.SetInt("PlayerIntelligence", classStats.intelligence);
        PlayerPrefs.SetInt("PlayerWisdom", classStats.wisdom);
        PlayerPrefs.SetInt("PlayerCharisma", classStats.charisma);

    }

    private void SetPartyClass(ClassStats classStats1, ClassStats classStats2, ClassStats classStats3)
    {
        PlayerPrefs.SetString("Party1ClassName", classStats1.className);
        PlayerPrefs.SetInt("Party1Strength", classStats1.strength);
        PlayerPrefs.SetInt("Party1Dexterity", classStats1.dexterity);
        PlayerPrefs.SetInt("Party1Constitution", classStats1.constitution);
        PlayerPrefs.SetInt("Party1Intelligence", classStats1.intelligence);
        PlayerPrefs.SetInt("Party1Wisdom", classStats1.wisdom);
        PlayerPrefs.SetInt("Party1Charisma", classStats1.charisma);

        PlayerPrefs.SetString("Party2ClassName", classStats2.className);
        PlayerPrefs.SetInt("Party2Strength", classStats2.strength);
        PlayerPrefs.SetInt("Party2Dexterity", classStats2.dexterity);
        PlayerPrefs.SetInt("Party2Constitution", classStats2.constitution);
        PlayerPrefs.SetInt("Party2Intelligence", classStats2.intelligence);
        PlayerPrefs.SetInt("Party2Wisdom", classStats2.wisdom);
        PlayerPrefs.SetInt("Party2Charisma", classStats2.charisma);

        PlayerPrefs.SetString("Party3ClassName", classStats3.className);
        PlayerPrefs.SetInt("Party3Strength", classStats3.strength);
        PlayerPrefs.SetInt("Party3Dexterity", classStats3.dexterity);
        PlayerPrefs.SetInt("Party3Constitution", classStats3.constitution);
        PlayerPrefs.SetInt("Party3Intelligence", classStats3.intelligence);
        PlayerPrefs.SetInt("Party3Wisdom", classStats3.wisdom);
        PlayerPrefs.SetInt("Party3Charisma", classStats3.charisma);
    }

    private void LoadMarketScene()
    {
        SceneManager.LoadScene("MarketScene");
    }
}
