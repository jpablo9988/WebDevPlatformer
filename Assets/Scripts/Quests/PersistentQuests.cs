using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PersistentQuests
{
    public static List<QuestDB> noQuests = new();
    public static List<QuestDB> noAchievements = new();
    public static bool hasAddedQuests = false;
    public static bool hasAddedAchievements = false;
    public static void UpdateDB(QuestDB db_type)
    {
        var obj = noQuests.FirstOrDefault(x => x.Type == db_type.Type);
        if (obj != null)
        {
            obj.Requierements = db_type.Requierements;
            obj.IsAchievement = db_type.IsAchievement;
        }
    }
}
