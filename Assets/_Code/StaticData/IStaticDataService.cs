public interface IStaticDataService : IService
{
    void LoadKitchenObjectConfigs();
    KitchenObjectConfig ForKitchenObject(KitchenObjectType type);
}