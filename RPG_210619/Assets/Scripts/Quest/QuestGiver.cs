using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    QuestList questList;
    public Quest quest;

    private bool assignedQuest = false;
    private bool helped = false;

    public List<string> askDialogue = new List<string>();
    public List<string> questSolvingDialogue = new List<string>();
    public List<string> completeDialogue = new List<string>();
    public List<string> afterCompleteDialogue = new List<string>();

    private void Start()
    {
        questList = PlayerManager.instance.player.GetComponent<QuestList>();

        if(quest != null)
        {
            quest.Init();
        }
    }

    public void GiveQuest()
    {
        if(!assignedQuest && !helped)
        {
            AssignQuest();
            DialogueSystem.instance.AddDialogues(askDialogue.ToArray());
        }
        else if(assignedQuest && !helped)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.instance.AddDialogues(afterCompleteDialogue.ToArray());
        }
    }

    private void AssignQuest()
    {
        assignedQuest = true;
        questList.AddQuest(quest);
    }

    private void CheckQuest()
    {
        if(quest.complete)
        {
            assignedQuest = false;
            helped = true;
            quest.GiveReward();
            DialogueSystem.instance.AddDialogues(completeDialogue.ToArray());

            questList.RemoveQuest(quest);
        }
        else
        {
            DialogueSystem.instance.AddDialogues(questSolvingDialogue.ToArray());
        }
    }
}
