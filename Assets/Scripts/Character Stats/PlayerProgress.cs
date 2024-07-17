using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProgress
{
    private static int mainQuestProgress;
    public static int MainQuestProgress
    {
        get { return mainQuestProgress; }
        set { mainQuestProgress = value; }
    }

    private static int subQuest_1Progress;
    public static int SubQuest_1Progress
    {
        get { return subQuest_1Progress; }
        set { subQuest_1Progress = value; }
    }

    private static int subQuest_2Progress;
    public static int SubQuest_2Progress
    {
        get { return subQuest_2Progress; }
        set { subQuest_2Progress = value; }
    }
}
