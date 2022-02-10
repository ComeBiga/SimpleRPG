using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal : PropertyAttribute
{
    public GoalType goalType;
    public int requirementID;
    public int requirementAmount;
    private int currentAmount;

    public bool isCompleted = false;

    public event System.Action OnGoalCompleted;

    public void AddAmount(int amount = 1)
    {
        currentAmount++;

        if(currentAmount >= requirementAmount)
        {
            Complete();
        }
    }

    private void Complete()
    {
        isCompleted = true;
        OnGoalCompleted.Invoke();
    }
}

public enum GoalType { Kill, Collect, Use }
