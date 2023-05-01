using Zenject;
using UnityEngine;

public class FactoriesInstaller : MonoInstaller
{
    [SerializeField] private KitchenObject _meatPrefab;
    [SerializeField] private KitchenObject _cheesePrefab;
    [SerializeField] private KitchenObject _cabbagePrefab;
    [SerializeField] private KitchenObject _tomatoPrefab;

    public override void InstallBindings()
    {
        Container
            .Bind<KitchenObjectsFactory>()
            .FromInstance(new KitchenObjectsFactory(_cabbagePrefab, _meatPrefab, _tomatoPrefab, _cheesePrefab))
            .AsSingle();
    }
}