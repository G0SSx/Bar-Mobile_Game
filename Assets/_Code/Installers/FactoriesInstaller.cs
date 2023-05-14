using Zenject;
using UnityEngine;

public class FactoriesInstaller : MonoInstaller
{
    [SerializeField] private KitchenObjectConfigsStorage _kitchenObjectConfigsStorage;
    [SerializeField] private IconsStorage _iconsStorage;
    [SerializeField] private GameObject _emptyIconPrefab;

    public override void InstallBindings()
    {
        IconsFactory iconsFactory = new IconsFactory(_iconsStorage, _emptyIconPrefab);
        
        Container
            .Bind<IconsFactory>()
            .FromInstance(iconsFactory)
            .AsSingle();

        Container
            .Bind<KitchenObjectsFactory>()
            .FromInstance(new KitchenObjectsFactory(_kitchenObjectConfigsStorage, iconsFactory))
            .AsSingle();
    }
}