using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InternalDice : MonoBehaviour
{
    [SerializeField] private TMP_Text diceText;

    public int diceResult;

    public void OnInternalDiceRolled()
    {
        if(diceResult == 0)
        {
            diceResult = Random.Range(1, 21);
            diceText.text = "Roll Result: " + diceResult.ToString();
            StartCoroutine(DiceResultReset());
        }
    }

    IEnumerator DiceResultReset()
    {
        yield return new WaitForSeconds(3);
        diceResult = 0;
    }
    
    void Start()
    {
        diceResult = 0;
    }

    
    void Update()
    {
        
    }
}
