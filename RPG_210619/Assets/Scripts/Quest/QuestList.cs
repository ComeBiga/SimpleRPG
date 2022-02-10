using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    public void AddQuest(Quest newQuest)
    {
        quests.Add(newQuest);
    }

    public void OnUpdateRequirement(int requirementID)
    {
        foreach(var quest in quests)
        {
            foreach(var goal in quest.goals)
            {
                if(goal.requirementID == requirementID)
                {
                    goal.AddAmount();
                }
            }
        }
    }

    public void RemoveQuest(Quest quest)
    {
        quests.Remove(quest);
    }
}
