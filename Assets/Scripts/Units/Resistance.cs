using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resistance : Stat
{
    //Resistance max value of 1 for 100% immunity, negative values increase damage
    private float Max = 1;

    protected new float CalculateFinalValue()
    {
        float finalValue = Base;

        for (int i = 0; i < Modifiers.Count; i++)
        {
            //Ignore modifier type for resistances, only care about the numerical value
            finalValue += Modifiers[i].Value;           
        }

        return Mathf.Min((float)System.Math.Round(finalValue), Max);
    }

    //TODO in damage step, do 1-resistance value for mult
}
