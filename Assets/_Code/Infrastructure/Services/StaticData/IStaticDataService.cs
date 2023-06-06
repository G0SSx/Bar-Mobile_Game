public interface IStaticDataService
{
    void LoadConfigs();
    KitchenObjectConfig ForKitchenObject(KitchenObjectType type);
    LevelConfig ForLevel(string levelKey);
}