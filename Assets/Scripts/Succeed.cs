using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Succeed : MonoBehaviour
{
    [SerializeField] TMP_Text succeedText ;
    // Start is called before the first frame update
    void Start()
    {
        if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_NORMAL)
        {
            succeedText.text = "DiceRoll Settings: NORMAL";
        }
        else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
        {
            succeedText.text = "DiceRoll Succeed: SUCCEED";
        }
        else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_FAIL)
        {
            succeedText.text = "DiceRoll Succeed: FAIL";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
