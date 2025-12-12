using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class UnitDataManager : MonoBehaviour
{
    // Singleton pattern for easy global access
    public static UnitDataManager Instance { get; private set; }

    // Dictionary to cache all UnitDefinitions, keyed by UnitID
    private Dictionary<string, UnitDefinition> unitDefinitionsCache = new Dictionary<string, UnitDefinition>();

    // This array is where you drag all your ScriptableObject assets in the Inspector
    [Header("Assign All Unit Definitions Here")]
    public UnitDefinition[] allUnitDefinitions;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Populate the cache on game start
        CacheUnitDefinitions();
    }

    private void CacheUnitDefinitions()
    {
        unitDefinitionsCache.Clear();
        if (allUnitDefinitions != null)
        {
            foreach (var definition in allUnitDefinitions)
            {
                if (definition != null && !string.IsNullOrEmpty(definition.UnitID))
                {
                    unitDefinitionsCache.Add(definition.UnitID, definition);
                }
            }
        }
        Debug.Log($"GameManager cached {unitDefinitionsCache.Count} Unit Definitions.");
    }

    // Public method to retrieve a definition by its ID
    public UnitDefinition GetUnitDefinition(string unitID)
    {
        if (unitDefinitionsCache.TryGetValue(unitID, out UnitDefinition definition))
        {
            return definition;
        }
        Debug.LogError($"UnitDefinition with ID '{unitID}' not found in cache!");
        return null;
    }
}