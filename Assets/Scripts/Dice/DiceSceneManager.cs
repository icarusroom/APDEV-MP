using UnityEngine;

public class DiceSceneManager : MonoBehaviour
{
    public void OnFinishedButtonClicked()
    {
        GameObject marketManagerObject = GameObject.Find("MarketManager"); 
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
