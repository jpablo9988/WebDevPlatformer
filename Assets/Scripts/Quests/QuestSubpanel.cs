using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestSubpanel : MonoBehaviour
{
    [SerializeField]
    private string QuestName = "Quests";
    [SerializeField]
    private string AchievementsName = "Achievements";
    [SerializeField]
    private TextMeshProUGUI title;

    private bool isAchievementOpen = false;

    public void SwitchList(bool isAchievement)
    {
        if (isAchievement != isAchievementOpen)
        {
            isAchievementOpen = isAchievement;
            QuestsManager.Instance.SwitchLists(isAchievement);
            if (isAchievement)
            {
                title.text = AchievementsName;
            }
            else
            {
                title.text = QuestName;
            }

        }
    }
}
