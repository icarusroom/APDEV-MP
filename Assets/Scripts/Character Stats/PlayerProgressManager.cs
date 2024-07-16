using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressManger: MonoBehaviour
{
    private void Start()
    {
        PlayerProgress.MainQuestProgress = 1;
        PlayerProgress.SubQuest_1Progress = 1;
        PlayerProgress.SubQuest_2Progress = 1;

        EventBroadcaster.Instance.AddObserver(EventNames.Player_Events.ON_MAINQUEST_PROGRESS, this.MainQuestProgress);
        EventBroadcaster.Instance.AddObserver(EventNames.Player_Events.ON_SUBQUEST_1QUEST_PROGRESS, this.SubQuest_1Progress);
        EventBroadcaster.Instance.AddObserver(EventNames.Player_Events.ON_SUBQUEST_2QUEST_PROGRESS, this.SubQuest_2Progress);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Player_Events.ON_MAINQUEST_PROGRESS);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Player_Events.ON_SUBQUEST_1QUEST_PROGRESS);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Player_Events.ON_SUBQUEST_2QUEST_PROGRESS);
    }

    public void MainQuestProgress()
    {
        PlayerProgress.MainQuestProgress++;
    }

    public void SubQuest_1Progress()
    {
        PlayerProgress.SubQuest_1Progress++;
    }

    public void SubQuest_2Progress()
    {
        PlayerProgress.SubQuest_2Progress++;
    }

}
