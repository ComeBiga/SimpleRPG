using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Quest
{
    public List<Goal> goals = new List<Goal>();

    public bool complete = false;
    public Item rewardItem;
    public int rewardXP;

    public void Init()
    {
        foreach(var goal in goals)
        {
            goal.OnGoalCompleted += CheckCompleted;
        }
    }

    public void CheckCompleted()
    {
        complete = goals.All(g => g.isCompleted);
    }

    public void GiveReward()
    {
        if (rewardItem != null) Inventory.instance.AddItem(rewardItem);

        PlayerManager.instance.player.GetComponent<BaseStats>().exp.GainXP(rewardXP);
    }
}
