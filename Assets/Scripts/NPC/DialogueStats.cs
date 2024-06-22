using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueStats
{
    private static int option1;

    public static int Option1
    {
        get { return option1; }
        set { option1 = value; }
    }

    private static int option2;

    public static int Option2
    {
        get { return option2; }
        set { option2 = value; }
    }

    private static string op1Type;

    public static string Op1Type
    {
        get { return op1Type; }
        set { op1Type = value; }
    }

    private static string op2Type;

    public static string Op2Type
    {
        get { return op2Type; }
        set { op2Type = value; }
    }

    private static string op1Text;

    public static string Op1Text
    {
        get { return op1Text; }
        set { op1Text = value; }
    }

    private static string op2Text;

    public static string Op2Text
    {
        get { return op2Text; }
        set { op2Text = value; }
    }
}
