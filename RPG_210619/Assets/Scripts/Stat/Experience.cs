using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Experience
{
    public int level = 1;

    [SerializeField]
    private int requireXP = 15;
    private int currentXP = 0;
    [SerializeField]
    private int progressVar = 1;

    public event System.Action<int, int> OnChangedExprience;
    public event System.Action OnChangedLevel;

    public Experience()
    {
        
    }

    public void CalculateRequireXP()
    {
        requireXP = (level * level) * progressVar;
    }

    public void GainXP(int amount)
    {
        currentXP += amount;

        if(currentXP >= requireXP)
        {
            LevelUp();

            currentXP -= requireXP;
            CalculateRequireXP();
        }

        if(OnChangedExprience != null)
            OnChangedExprience.Invoke(currentXP, requireXP);
    }

    void LevelUp()
    {
        level++;

        if (OnChangedLevel != null)
            OnChangedLevel.Invoke();
    }
}
