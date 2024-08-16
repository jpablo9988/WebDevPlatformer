using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quests")]
public class QuestType : ScriptableObject
{

    public string description;
    public QuestActivationType activationType;
    public int amountRequiered;
}
public enum QuestActivationType
{
    JUMP_INPUT,
    MOVEMENT_INPUT,
    LOCATION
}
