using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public int value;
    public float progressVar;
    public List<int> modifiers = new List<int>();

    public void AddModifiers(int modifier)
    {
        modifiers.Add(modifier);
    }

    public void AddModifier(int modifier)
    {
        modifiers.Add(modifier);
    }

    public int GetModifiers()
    {
        int total = 0;

        modifiers.ForEach(m => total += m);

        return total;
    }

    public int GetModifiedValue()
    {
        return value + GetModifiers();
    }

    public void OnLevelUp()
    {
        float result;
        if (value == 0)
        {
            result = 1 * progressVar;
        }
        else
        {
            result = (float)value * progressVar;
        }

        value = (int)result;
    }
}
