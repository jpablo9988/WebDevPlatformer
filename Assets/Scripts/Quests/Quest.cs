using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quest : MonoBehaviour, IQuest
{
    [SerializeField]
    private QuestType type;

    public QuestType Type { get { return type; } private set { type = value;  } }

    [SerializeField]
    TextMeshProUGUI _descriptionText;
    [SerializeField]
    TextMeshProUGUI _requierements;
    [SerializeField]
    Image _checkImage;

    public bool isComplete;
    [SerializeField]
    private int noActivations = 0;

    private QuestDB db_ref;
    private void Awake()
    {
        RedrawNode();
    }

    public void AddQuestToNode(QuestDB db_Quest)
    {
        this.type = db_Quest.Type;
        this.isComplete = db_Quest.IsComplete;
        this.noActivations = db_Quest.Requierements;
        db_ref = db_Quest;
        RedrawNode();
    }

    private void RedrawNode()
    {
        _descriptionText.text = type.description;
        _checkImage.enabled = isComplete;
        _requierements.text = noActivations + "/" + type.amountRequiered;
    }

    public void CheckForActivation(int amount)
    {
        noActivations += amount;
        this.db_ref.Requierements += amount;
        _requierements.text = noActivations + "/" + type.amountRequiered;
        if (type.amountRequiered <= noActivations)
        {
            isComplete = true;
            this.db_ref.IsComplete = true;
            _checkImage.enabled = true;
        }
        PersistentQuests.UpdateDB(this.db_ref);
    }
}
