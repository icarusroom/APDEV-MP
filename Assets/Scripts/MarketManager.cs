using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketManager : MonoBehaviour
{
    private Scene gameScene;

    void Start()
    {
        gameScene = SceneManager.GetSceneByName("MarketScene");
    }

    public void OnDiceButtonClicked(string sceneName)
    {

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
            else
            {
                obj.SetActive(active); 
            }

        }
    }


    public void OnDiceSceneClosed()
    {

        // Unload the Dice Scene
        SceneManager.UnloadSceneAsync("DiceRoll");

        // Re-enable all objects in the GameScene
        GameSceneOBJ(gameScene, true);
    }
}
