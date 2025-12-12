using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Dagger,
    Sword,
    GreatSword,
    Katana,
    Stave,
    Rod,
    Bow,
    Hammer,
    Spear,
    Instrument,
    Whip,
    ThrowingWeapon,
    Gun,
    Mace,
    Fist,
    LightShield,
    HeavyShield,
    Hat,
    Helm,
    Clothes,
    LightArmor,
    HeavyArmor,
    Robe,
    Accessory
}

public class Equipment
{
    public string ID;
    public string Name;
    public EquipmentType Type;

    //Stat modifiers
    public List<StatModifier> StatModifiers = new List<StatModifier>();

    //Passives
    public List<Passive> Passives = new List<Passive>();

    public List<Skill> Skills = new List<Skill>();
}
