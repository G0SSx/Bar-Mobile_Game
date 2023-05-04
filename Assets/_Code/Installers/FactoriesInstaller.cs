using Zenject;
using UnityEngine;

public class FactoriesInstaller : MonoInstaller
{
    [SerializeField] private KitchenObjectConfigsStorage _storage;

    public override void InstallBindings()
    {
        Container
            .Bind<KitchenObjectsFactory>()
            .FromInstance(new KitchenObjectsFactory(_storage))
            .AsSingle();
    }
}