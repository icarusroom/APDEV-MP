using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class PlayerProgressManger: MonoBehaviour
{
    public static PlayerProgressManger Instance;

    [SerializeField]
    private GameObject _goodEnding;
    [SerializeField]
    private GameObject _badEnding;
    [SerializeField]
    private GameObject _neutralEnding;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        PlayerProgress.MainQuestProgress = 1;
        PlayerProgress.SubQuest_1Progress = 1;
        PlayerProgress.SubQuest_2Progress = 1;

        PlayerProgress.NegativeChoiceCounter = 0;
        PlayerProgress.PositiveChoiceCounter = 0;

        Debug.Log(PlayerProgress.MainQuestProgress);
        Debug.Log(PlayerProgress.SubQuest_1Progress);
        Debug.Log(PlayerProgress.SubQuest_2Progress);

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
        PlayerProgress.MainQuestProgress = PlayerProgress.MainQuestProgress + 1;

        if(PlayerProgress.MainQuestProgress > 4)
        {
            this.GameEnding();
        }
    }

    public void SubQuest_1Progress()
    {
        PlayerProgress.SubQuest_1Progress = PlayerProgress.SubQuest_1Progress + 1;

        if(PlayerProgress.SubQuest_1Progress > 4)
        {
            if(LingeringEffect())
            {
                PlayerPrefs.SetInt("PlayerIntelligence", PlayerPrefs.GetInt("PlayerIntelligence") + 3);
                PlayerPrefs.SetInt("PlayerStrength", PlayerPrefs.GetInt("PlayerStrength") + 3);
            }
            else
            {
                PlayerPrefs.SetInt("PlayerIntelligence", PlayerPrefs.GetInt("PlayerIntelligence") - 3);
                PlayerPrefs.SetInt("PlayerStrength", PlayerPrefs.GetInt("PlayerStrength") - 3);
            }
        }
    }

    public void SubQuest_2Progress()
    {
        PlayerProgress.SubQuest_2Progress = PlayerProgress.SubQuest_2Progress + 1;

        if (PlayerProgress.SubQuest_2Progress > 4)
        {
            if(LingeringEffect())
            {
                PlayerPrefs.SetInt("PlayerCharisma", PlayerPrefs.GetInt("PlayerCharisma") + 3);
                PlayerPrefs.SetInt("PlayerWisdom", PlayerPrefs.GetInt("PlayerWisdom") + 3);
            }
            else
            {
                PlayerPrefs.SetInt("PlayerCharisma", PlayerPrefs.GetInt("PlayerCharisma") - 3);
                PlayerPrefs.SetInt("PlayerWisdom", PlayerPrefs.GetInt("PlayerWisdom") - 3);
            }
        }
    }

    private void GameEnding()
    {
        if(PlayerProgress.PositiveChoiceCounter > PlayerProgress.NegativeChoiceCounter)
        {
            this._goodEnding.SetActive(true);
        }

        if (PlayerProgress.PositiveChoiceCounter < PlayerProgress.NegativeChoiceCounter)
        {
            this._badEnding.SetActive(true);
        }

        else
        {
            this._neutralEnding.SetActive(true);
        }
    }

    private bool LingeringEffect()
    {
        if (PlayerProgress.PositiveChoiceCounter > PlayerProgress.NegativeChoiceCounter)
        {
            return true;
        }

        if (PlayerProgress.PositiveChoiceCounter < PlayerProgress.NegativeChoiceCounter)
        {
            return false;
        }

        else
        {
            return true;
        }
    }
}
