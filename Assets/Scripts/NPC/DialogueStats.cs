using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueStats
{
    //Stores the value of option 1 skillcheck
    private static int option1;
    public static int Option1
    {
        get { return option1; }
        set { option1 = value; }
    }

    //Stores the value of option 2 skillcheck
    private static int option2;
    public static int Option2
    {
        get { return option2; }
        set { option2 = value; }
    }

    //Stores the string of option 1 skill type (STR, INT, etc...)
    private static string op1Type;
    public static string Op1Type
    {
        get { return op1Type; }
        set { op1Type = value; }
    }

    //Stores the string of option 1 skill type (STR, INT, etc...)
    private static string op2Type;
    public static string Op2Type
    {
        get { return op2Type; }
        set { op2Type = value; }
    }


    private static string dialogueHeader;
    public static string DialogueHeader
    {
        get { return dialogueHeader; }
        set { dialogueHeader = value; }
    }
    private static string op1Description;
    public static string Op1Description
    {
        get { return op1Description; }
        set { op1Description = value; }
    }

    private static string op2Description;
    public static string Op2Description
    {
        get { return op2Description; }
        set { op2Description = value; }
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
