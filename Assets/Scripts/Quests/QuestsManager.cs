using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestsManager : SingletonClass<QuestsManager>
{
    public delegate void EventWithActivationType(QuestActivationType type);

    public static event EventWithActivationType ProgressEvent;


    [SerializeField]
    private List<Quest> questList;
    [SerializeField]
    private List<QuestType> allQuests;
    [SerializeField]
    private List<QuestType> allAchievements;

    public List<Quest> QuestList { get { return questList; } set { questList = value; } }
    
    public void ProgressQuests(QuestActivationType type)
    {
        ProgressEvent?.Invoke(type);
    }
    private void OnEnable()
    {
        ProgressEvent += CheckQuest;
    }
    private void OnDisable()
    {
        ProgressEvent -= CheckQuest;
    }
    private void Start()
    {
        // -- create QuestDB classes -- //
        if (!PersistentQuests.hasAddedQuests)
        {
            foreach (QuestType types in allQuests)
            {
                QuestDB dbQuest = new (types, 0, false, false);
                PersistentQuests.noQuests.Add(dbQuest);
                PersistentQuests.hasAddedQuests = true;
            }
        }
        if (!PersistentQuests.hasAddedAchievements)
        {
            foreach (QuestType types in allAchievements)
            {
                QuestDB dbQuest = new (types, 0, false, true);
                PersistentQuests.noAchievements.Add(dbQuest);
                PersistentQuests.hasAddedAchievements = true;
            }
        }
        else
        {
            foreach (QuestDB questInDB in PersistentQuests.noQuests)
            {
                AddQuest(questInDB);
            }
        }
        SwitchLists(false);
        
    }
    public void SwitchLists(bool toAchievements)
    {
        List<Quest> activeQuests = questList.Where(value => { return value.gameObject.activeSelf == true; }).ToList();
        foreach (Quest q in activeQuests)
        {
            q.gameObject.SetActive(false);
        }
        if (toAchievements)
        {
            LoadList(PersistentQuests.noAchievements);
        }
        else
        {
            LoadList(PersistentQuests.noQuests);
        }
    }
    private void LoadList(List<QuestDB> types)
    {
        List<Quest> activeQuests = questList.Where(value => { return value.gameObject.activeSelf == false; }).ToList();
        foreach (Quest q in activeQuests)
        {
            q.gameObject.SetActive(false);
        }
        foreach(QuestDB type in types)
        {
            AddQuest(type);
        }
    }
    public void AddQuest(QuestDB db_Quest)
    {
        Quest quest = questList.Where(value => { return value.gameObject.activeSelf == false; }).FirstOrDefault();
        if (quest != null)
        {
            quest.gameObject.SetActive(true);
            quest.AddQuestToNode(db_Quest);
        }
    }

    private void CheckQuest (QuestActivationType actType)
    {
        List<Quest> questsToCheck = questList.Where (value => {
            if (value.Type != null && value.gameObject.activeSelf)
            {
                return (value.Type.activationType == actType && !value.isComplete);
            }
            else return false;
        }).ToList();
        foreach (Quest quest in questsToCheck)
        {
            quest.CheckForActivation(1);
        }
    }

    
}
