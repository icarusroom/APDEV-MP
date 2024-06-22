using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MarketManager : MonoBehaviour
{
    private Scene gameScene;
    [SerializeField]
    private MarketUIDocument marketUIDocument;

    void Start()
    {
        gameScene = SceneManager.GetSceneByName("MarketScene");
        if (marketUIDocument == null)
        {
            Debug.LogError("MarketUIDocument reference not set in MarketManager.");
        }
    }

    public void OnDiceButtonClicked(string sceneName)
    {
        Debug.Log("OnDiceButtonClicked: Loading scene " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        GameSceneOBJ(gameScene, false);
    }


    private void GameSceneOBJ(Scene scene, bool active)
    {
        foreach (GameObject obj in scene.GetRootGameObjects())
        {
            if (obj.name == "MarketManager") //Will change soon to accomodate all area scenes

            {
                obj.SetActive(true); 
            }
            else if (obj.name == "MarketUIDocument")
            {
                obj.SetActive(false);
            }
            else
            {
                obj.SetActive(active);
            }

        }
    }


    public void OnDiceSceneClosed()
    {
        Debug.Log("OnDiceSceneClosed: Unloading DiceRoll scene");
        // Unload the Dice Scene
        SceneManager.UnloadSceneAsync("DiceRoll");
        // Re-enable all objects in the GameScene
        GameSceneOBJ(gameScene, true);

        if (marketUIDocument != null)
        {
            Debug.Log("OnDiceSceneClosed: Hiding Dialogue Box");
            marketUIDocument.OnDiceSceneClosed();
        }
    }
}
