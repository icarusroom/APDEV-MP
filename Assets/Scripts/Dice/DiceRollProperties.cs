using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DiceRollProperties
{
    private static int diceRollResult;

    public static int DiceRollResult
    {
        get { return diceRollResult; }
        set { diceRollResult = value; }
    }
}
