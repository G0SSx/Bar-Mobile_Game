using UnityEngine;

public class KitchenObjectsFactory
{
    private KitchenObjectConfigsStorage _storage;

    public KitchenObjectsFactory(KitchenObjectConfigsStorage storage) => 
        _storage = storage;

    public KitchenObject CreateKitchenObject(KitchenObjectType type)
    {
        KitchenObject kitchenObject = null;

        switch (type)
        {
            case KitchenObjectType.Tomato:
                kitchenObject = Object.Instantiate(_storage.Tomato.Prefab);
                SetupKitchenObject(kitchenObject, _storage.Tomato);
                break;
            case KitchenObjectType.MeatUncooked:
                kitchenObject = Object.Instantiate(_storage.UncookedMeatConfig.Prefab);
                SetupKitchenObject(kitchenObject, _storage.UncookedMeatConfig);
                break;
            case KitchenObjectType.MeatCooked:
                kitchenObject = Object.Instantiate(_storage.CookedMeatConfig.Prefab);
                SetupKitchenObject(kitchenObject, _storage.CookedMeatConfig);
                break;
            case KitchenObjectType.MeatBurned:
                kitchenObject = Object.Instantiate(_storage.BurnedMeatConfig.Prefab);
                SetupKitchenObject(kitchenObject, _storage.BurnedMeatConfig);
                break;
            case KitchenObjectType.Cheese:
                kitchenObject = Object.Instantiate(_storage.Cheese.Prefab);
                SetupKitchenObject(kitchenObject, _storage.Cheese);
                break;
            case KitchenObjectType.Cabbage:
                kitchenObject = Object.Instantiate(_storage.Cabbage.Prefab);
                SetupKitchenObject(kitchenObject, _storage.Cabbage);
                break;
            case KitchenObjectType.Plate:
                kitchenObject = Object.Instantiate(_storage.Plate.Prefab);
                SetupKitchenObject(kitchenObject, _storage.Plate);
                break;
        }

        return kitchenObject;
    }

    public KitchenObject CreateSliceOfKitchenObject(KitchenObjectType type)
    {
        KitchenObject kitchenObject = null;

        switch (type)
        {
            case KitchenObjectType.Tomato:
                kitchenObject = Object.Instantiate(_storage.TomatoSliced.Prefab);
                SetupKitchenObject(kitchenObject, _storage.TomatoSliced);
                break;
            case KitchenObjectType.Cheese:
                kitchenObject = Object.Instantiate(_storage.CheeseSliced.Prefab);
                SetupKitchenObject(kitchenObject, _storage.CheeseSliced);
                break;
            case KitchenObjectType.Cabbage:
                kitchenObject = Object.Instantiate(_storage.CabbageSliced.Prefab);
                SetupKitchenObject(kitchenObject, _storage.CabbageSliced);
                break;
        }

        return kitchenObject;
    }

    private void SetupKitchenObject(KitchenObject kitchenObject, KitchenObjectConfig config) =>
        kitchenObject.Init(config.IsCuttable, config.Type, config.IsCooked);
}