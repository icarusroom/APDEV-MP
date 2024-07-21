using UnityEngine;

public class DiceSceneManager : MonoBehaviour
{
    public void OnFinishedButtonClicked()
    {
        GameObject marketManagerObject = GameObject.Find("MarketManager"); //Will change soon to accomodate all area scenes
        if (marketManagerObject != null)
        {
            MarketManager marketManager = marketManagerObject.GetComponent<MarketManager>();
            if (marketManager != null)
            {
                marketManager.OnDiceSceneClosed();
            }

        }
    }
}
