using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDefinition", menuName = "Scriptable Objects/EnemyDefinition")]
public class EnemyDefinition : ScriptableObject
{
    [Header("Identity")]
    public string EnemyID;
    public string EnemyName;
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
}
