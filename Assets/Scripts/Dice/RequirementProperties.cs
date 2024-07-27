using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RequirementProperties
{
    private static int requirement;
    private static string opt;
    private static int optionChosen;

    public static int statsRequirement
    {
        get { return requirement; }
        set { requirement = value; }
    }

    public static string playerOpt
    {
        get { return opt; }
        set {opt = value; }
    }

    public static int OptionChosen
    {
        get { return optionChosen; }
        set { optionChosen = value; }
    }
}
