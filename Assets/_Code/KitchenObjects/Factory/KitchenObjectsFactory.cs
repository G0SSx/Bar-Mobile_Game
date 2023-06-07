using UnityEngine;

public class KitchenObjectsFactory : IKitchenObjectsFactory
{
    private readonly IAssets _assets;
    private readonly IStaticDataService _staticData;

    public KitchenObjectsFactory(IAssets assets, IStaticDataService staticData)
    {
        _assets = assets; 
        _staticData = staticData;
    }

    public KitchenObject CreateKitchenObject(KitchenObjectType type) =>
        CreateKitchenObjectAndInit(type);

    public KitchenObject CreateSlicedKitchenObject(KitchenObjectType type) =>
        CreateSlicedKitchenObjectAndInit(type);

    public Sprite GetSpriteByType(KitchenObjectType type) =>
        _staticData.ForKitchenObject(type).Icon;

    private KitchenObject CreateSlicedKitchenObjectAndInit(KitchenObjectType type)
    {
        KitchenObject kitchenObject = null;

        switch (type)
        {
            case KitchenObjectType.Tomato:
                kitchenObject = Instantiate(AssetPath.SlicedTomato);
                SetupKitchenObject(kitchenObject, KitchenObjectType.TomatoSliced);
                break;
            case KitchenObjectType.Cheese:
                kitchenObject = Instantiate(AssetPath.SlicedCheese);
                SetupKitchenObject(kitchenObject, KitchenObjectType.CheeseSliced);
                break;
            case KitchenObjectType.Cabbage:
                kitchenObject = Instantiate(AssetPath.SlicedCabbage);
                SetupKitchenObject(kitchenObject, KitchenObjectType.CabbageSliced);
                break;
        }

        return kitchenObject;
    }

    private KitchenObject CreateKitchenObjectAndInit(KitchenObjectType type)
    {
        KitchenObject kitchenObject = null;

        switch (type)
        {
            case KitchenObjectType.Tomato:
                kitchenObject = Instantiate(AssetPath.Tomato);
                SetupKitchenObject(kitchenObject, KitchenObjectType.Tomato);
                break;
            case KitchenObjectType.MeatUncooked:
                kitchenObject = Instantiate(AssetPath.MeatUncooked);
                SetupKitchenObject(kitchenObject, KitchenObjectType.MeatUncooked);
                break;
            case KitchenObjectType.MeatCooked:
                kitchenObject = Instantiate(AssetPath.MeatCooked);
                SetupKitchenObject(kitchenObject, KitchenObjectType.MeatCooked);
                break;
            case KitchenObjectType.MeatBurned:
                kitchenObject = Instantiate(AssetPath.MeatBurned);
                SetupKitchenObject(kitchenObject, KitchenObjectType.MeatBurned);
                break;
            case KitchenObjectType.Cheese:
                kitchenObject = Instantiate(AssetPath.Cheese);
                SetupKitchenObject(kitchenObject, KitchenObjectType.Cheese);
                break;
            case KitchenObjectType.Cabbage:
                kitchenObject = Instantiate(AssetPath.Cabbage);
                SetupKitchenObject(kitchenObject, KitchenObjectType.Cabbage);
                break;
            case KitchenObjectType.Plate:
                kitchenObject = InstantiateWithZenject(AssetPath.Plate);
                SetupKitchenObject(kitchenObject, KitchenObjectType.Plate);
                break;
            case KitchenObjectType.Bread:
                kitchenObject = Instantiate(AssetPath.Bread);
                SetupKitchenObject(kitchenObject, KitchenObjectType.Bread);
                break;
        }

        return kitchenObject;
    }

    private KitchenObject Instantiate(string path) =>
        _assets.Instantiate(path)
            .GetComponent<KitchenObject>();

    private KitchenObject InstantiateWithZenject(string path) =>
        _assets.InstantiateWithZenject(path)
            .GetComponent<KitchenObject>();

    private void SetupKitchenObject(KitchenObject kitchenObject, KitchenObjectType type)
    {
        KitchenObjectConfig config = _staticData.ForKitchenObject(type);
        kitchenObject.Init(config.IsCuttable, config.Type, config.IsCooked, config.Icon);
    }
}