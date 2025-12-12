using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    MaxHP,
    MP,
    Attack,
    Magic,
    Defense,
    Spirit,
    FireResistance,
    IceResistance,
    LightningResistance,
    WindResistance ,    
    WaterResistance,
    EarthResistance,
    LightResistance,
    DarkResistance
}

[System.Serializable]
public class Unit : MonoBehaviour
{
    //Unit base class
    
    //Stats
    public float HP;

    public Stat MaxHP = new Stat();
    public Stat MP = new Stat();
    public Stat Attack = new Stat();
    public Stat Magic = new Stat();
    public Stat Defense = new Stat();
    public Stat Spirit = new Stat();

    //Elemental Resistances, value from 0 to 1 that inversely multiplies into damage calc
    public Stat FireResistance = new Resistance();
    public Stat IceResistance = new Resistance();
    public Stat LightningResistance = new Resistance();
    public Stat WindResistance = new Resistance();
    public Stat WaterResistance = new Resistance();
    public Stat EarthResistance = new Resistance();
    public Stat LightResistance = new Resistance();
    public Stat DarkResistance = new Resistance();

    //Tags such as "Human" "Dragon" "Plant" etc. for fun interactions
    public List<string> Tags = new List<string>();

    //List of usable skills
    public List<Skill> Skills = new List<Skill>();

    //List of passives
    public List<Passive> Passives = new List<Passive>();

    private List<StatModifier> StatModifiers = new List<StatModifier>();

    public Animator Animator;
    private bool _DoneAnimating = false;
    
    public Stat GetStat(StatType type)
    {
        switch (type) {
            case StatType.MaxHP:
                return MaxHP;
            case StatType.MP:
                return MP;
            case StatType.Attack:
                return Attack;
            case StatType.Magic:
                return Magic;
            case StatType.Defense:
                return Defense;
            case StatType.Spirit:
                return Spirit;
            case StatType.FireResistance:
                return FireResistance;
            case StatType.IceResistance:
                return IceResistance;
            case StatType.LightningResistance:
                return LightningResistance;
            case StatType.WindResistance:
                return WindResistance;
            case StatType.WaterResistance:
                return WaterResistance;
            case StatType.EarthResistance:
                return EarthResistance;
            case StatType.LightResistance:
                return LightResistance;
            case StatType.DarkResistance:
                return DarkResistance;    
        }

        //Should never fall into this but will need to double check it
        return null;
    }

    public void AddModifier(StatModifier statModifier)
    {
        StatModifiers.Add(statModifier);
        GetStat(statModifier.TargetStat).AddModifier(statModifier);
    }

    public bool RemoveModifier(StatModifier statModifier)
    {
        if (StatModifiers.Remove(statModifier))
        {
            return GetStat(statModifier.TargetStat).RemoveModifier(statModifier);
        }
        return false;
    }

    public void SetAnimatorTrigger(string trigger){
        Animator.SetTrigger(trigger);
    }

    public bool IsAnimatorComplete(){        
        return _DoneAnimating;
    }

    public void AnimationComplete(){
        Debug.Log($"{name} Attack Ended");
        _DoneAnimating = true;
    }
    
    public void AnimationStarted(){
        Debug.Log($"{name} Attack Started");
        _DoneAnimating = false;
    }
}