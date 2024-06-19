using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeveloperProperties
{
    private static EDiceRoll diceRoll = EDiceRoll.DICE_ROLL_NORMAL;

    public static EDiceRoll DiceRoll
    {
        get { return diceRoll; }
        set { diceRoll = value; }
    }

}



