using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CombatProperties
{
    private static bool combatResult;
    public static bool CombatResult
    {
        get { return combatResult; }
        set { combatResult = value; }
    }
}
