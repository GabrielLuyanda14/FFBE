using UnityEngine;

[System.Serializable]
public class UnitInstance : Unit
{    
    public string ID;

    public int currentLevel;
    public int currentExp;

    //TODO equipment

    public void Initialize()
    {
        // 1. Grab the definition from the GameManager
        UnitDefinition definition = GameManager.Instance.GetUnitDefinition(ID);

        if (definition == null)
        {
            Debug.LogError($"Failed to initialize UnitInstance. Definition for ID: {ID} is null.");
            return;
        }

        // 2. Apply the Base Stat values from the Definition to the Unit's Stat objects
        // (Assuming you added a public setter for 'Base' in Stat.cs as discussed previously)

        // Core Stats
        MaxHP.BaseValue = definition.baseHP;
        MP.BaseValue = definition.baseMP;
        Attack.BaseValue = definition.baseATK;
        Magic.BaseValue = definition.baseMAG;
        Defense.BaseValue = definition.baseDEF;
        Spirit.BaseValue = definition.baseSPR;

        // Resistances
        FireResistance.BaseValue = definition.BaseFireResist;
        IceResistance.BaseValue = definition.BaseIceResist;
        WindResistance.BaseValue = definition.BaseWindResist;
        WaterResistance.BaseValue = definition.BaseWaterResist;
        EarthResistance.BaseValue = definition.BaseEarthResist;
        LightningResistance.BaseValue = definition.BaseLightningResist;
        LightResistance.BaseValue = definition.BaseLightResist;
        DarkResistance.BaseValue = definition.BaseDarkResist;

        // Set current HP/MP to max for new units
        HP = MaxHP.Value;
        // Note: You would typically handle level growth here too, 
        // e.g., MaxHP.BaseValue += CalculateLevelGrowth(definition, currentLevel);

        GetComponent<Animator>().runtimeAnimatorController = definition.Animator;

        Debug.Log($"{definition.UnitName} initialized with MaxHP Base: {MaxHP.BaseValue}");
    }

    public void Start()
    {
        Initialize();
    }
}
