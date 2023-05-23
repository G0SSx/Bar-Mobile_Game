using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private const string KitchenObjectConfigsPath = "";
    
    private Dictionary<KitchenObjectType, KitchenObjectConfig> _kitchenObjects;

    public void LoadKitchenObjectConfigs() => 
        _kitchenObjects = Resources
            .LoadAll<KitchenObjectConfig>(KitchenObjectConfigsPath)
            .ToDictionary(key => key.Type, value => value);

    public KitchenObjectConfig ForKitchenObject(KitchenObjectType type) => 
        _kitchenObjects.TryGetValue(type, out KitchenObjectConfig config)
            ? config
            : null;
}