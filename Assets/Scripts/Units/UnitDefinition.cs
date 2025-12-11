using Unity.Android.Gradle.Manifest;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitDefinition", menuName = "Scriptable Objects/UnitDefinition")]
public class UnitDefinition : ScriptableObject
{
    [Header("Identity")]
    public string UnitID;
    public string UnitName;    
    public int baseRarity;
    public AnimatorOverrideController Animator;

    [Header("Base Stats")]
    public float baseHP;
    public float baseMP;
    public float baseATK;
    public float baseDEF;
    public float baseMAG;
    public float baseSPR;
    
    [Header("Resistances")]
    public float BaseFireResist;
    public float BaseIceResist;
    public float BaseWindResist;
    public float BaseWaterResist;
    public float BaseEarthResist;
    public float BaseLightningResist;
    public float BaseLightResist;
    public float BaseDarkResist;

    //TODO status resists

    [Header("Growth")]
    public AnimationCurve statGrowthCurve; // Defines how stats scale to max level
    public int maxLevel = 100;

    //TODO equipment values
}