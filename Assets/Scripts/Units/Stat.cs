using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] protected float Base;
    [SerializeField] protected float CachedValue;
    protected List<StatModifier> Modifiers = new List<StatModifier>();
    protected bool isDirty = true;

    public float BaseValue
    {
        get { return Base; }
        set { Base = value; isDirty = true; } // Setting the base value should always dirty the cache
    }

    public float Value
    {
        get {
            if (isDirty)
            {
                CachedValue = CalculateFinalValue();
                isDirty = false;
            }
            return CachedValue;
        }
    }

    protected float CalculateFinalValue()
    {
        float finalValue = Base;
        float sumPercentAdd = 0;
        float sumFlatValues = 0;

        for (int i = 0; i < Modifiers.Count; i++)
        {
            StatModifier mod = Modifiers[i];

            if (mod.Type == ModifierType.Flat)
            {
                sumFlatValues += mod.Value;
            }
            else if (mod.Type == ModifierType.Percent)
            {
                sumPercentAdd += mod.Value;
            }
        }

        finalValue *= (1 + sumPercentAdd);
        finalValue += sumFlatValues;

        return (float)System.Math.Round(finalValue);
    }

    public void AddModifier(StatModifier modifier)
    {
        Modifiers.Add(modifier);
        isDirty = true;
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        if (Modifiers.Remove(modifier))
        {
            isDirty = true;
            return true;
        }
        return false;
    }
}

public enum ModifierType
{
    Flat,
    Percent
}

public class StatModifier
{
    public float Value;
    public ModifierType Type;
    public StatType TargetStat;
    public object Source; //Helps track WHERE the bonus came from (e.g., the Sword object)

    public StatModifier(float value, ModifierType type, object source = null)
    {
        Value = value;
        Type = type;
        Source = source;
    }
}