using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private Dictionary<KitchenObjectType, KitchenObjectConfig> _kitchenObjects;
    private Dictionary<string, LevelConfig> _levels;

    public void LoadConfigs()
    {
        _kitchenObjects = Resources
            .LoadAll<KitchenObjectConfig>(AssetPath.KitchenObjectConfigs)
            .ToDictionary(key => key.Type, value => value);

        _levels = Resources
            .LoadAll<LevelConfig>(AssetPath.LevelConfigs)
            .ToDictionary(key => key.LevelKey, value => value);
    }

    public KitchenObjectConfig ForKitchenObject(KitchenObjectType type) =>
        _kitchenObjects.TryGetValue(type, out KitchenObjectConfig config)
            ? config
            : null;

    public LevelConfig ForLevel(string levelKey) =>
        _levels.TryGetValue(levelKey, out LevelConfig config)
            ? config 
            : null;
}