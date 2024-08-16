using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDB
{
    public QuestType Type { get; set; }
    public int Requierements { get; set; }
    public bool IsComplete { get; set; }
    public bool IsAchievement { get; set; }
    public QuestDB (QuestType type, int requierements, bool isComplete, bool isAchievement = false)
    {
        Type = type;
        Requierements = requierements;
        IsComplete = isComplete;
        IsAchievement = isAchievement;
    }

}
