using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleEntrance : MonoBehaviour
{
    private Scene gameScene;

    private void Start()
    {
        gameScene = SceneManager.GetSceneByName("MarketScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(BossBattle());
        }


        IEnumerator BossBattle()
        {
            SceneManager.LoadScene("CombatScene", LoadSceneMode.Additive);
            GameSceneOBJ(gameScene, false);

            yield return new WaitUntil(() => MarketManager.Instance.IsCombatDone);

            bool combatResult = CombatProperties.CombatResult;

            if (combatResult)
            {
                Debug.Log("COMBAT WON");
            }
            else
            {
                Debug.Log("COMBAT LOST");
            }

            MarketManager.Instance.IsCombatDone = false;
        }
    }

    private void GameSceneOBJ(Scene scene, bool active)
    {
        foreach (GameObject obj in scene.GetRootGameObjects())
        {
            if (obj.name == "MarketManager")
            {
                obj.SetActive(true);
            }
            else if (obj.name == "MarketUIDocument")
            {
                obj.SetActive(true);
            }
            else if (obj.name == "EventSystem")
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(active);
            }
        }
    }   
}
