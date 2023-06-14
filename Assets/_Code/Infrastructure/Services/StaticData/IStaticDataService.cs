using _Code.Configs;
using _Code.KitchenObjects;

namespace _Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void LoadConfigs();
        KitchenObjectConfig ForKitchenObject(KitchenObjectType type);
        LevelConfig ForLevel(string levelKey);
    }
}