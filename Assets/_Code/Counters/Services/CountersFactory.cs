using UnityEngine;

public class CountersFactory : ICountersFactory
{
    private readonly IAssets _assets;

    public CountersFactory(IAssets assets) => 
        _assets = assets;

    public GameObject CreateCounterOfType(Vector3 position, Quaternion rotationt, CounterType type, 
        KitchenObjectType kitchenObjectType)
    {
        GameObject counterObject = null;

        switch (type)
        {
            case CounterType.Unknown:
                break;
            case CounterType.Clear:
                counterObject = CreateClearCounter();
                break;
            case CounterType.Stove:
                counterObject = CreateStoveCounter();
                break;
            case CounterType.Cutter:
                counterObject = CreateCutterCounter();
                break;
            case CounterType.Container:
                counterObject = CreateCountainerCounter(kitchenObjectType);
                break;
            case CounterType.Delivery:
                counterObject = CreateDeliveryCounter();
                break;
            case CounterType.Trash:
                counterObject = CreateTrashCounter();
                break;
            case CounterType.Plates:
                counterObject = CreatePlatesCounter();
                break;
            default:
                break;
        }

        if (counterObject != null)
        {
            counterObject.transform.position = position;
            counterObject.transform.rotation = rotationt;
        }

        return counterObject;
    }

    public GameObject CreateClearCounter() =>
        _assets.Instantiate(AssetPath.ClearCounter);

    public GameObject CreateCountainerCounter(KitchenObjectType type)
    {
        GameObject counter = _assets.InstantiateWithZenject(AssetPath.ContainerCounter);

        counter.GetComponent<ContainerCounter>()
            .KitchenObjectType = type;

        return counter;
    }

    public GameObject CreateCutterCounter() =>
        _assets.InstantiateWithZenject(AssetPath.CutterCounter);

    public GameObject CreateDeliveryCounter() =>
        _assets.InstantiateWithZenject(AssetPath.DeliveryCounter);

    public GameObject CreatePlatesCounter() =>
        _assets.InstantiateWithZenject(AssetPath.PlatesCounter);

    public GameObject CreateStoveCounter() =>
        _assets.InstantiateWithZenject(AssetPath.StoveCounter);

    public GameObject CreateTrashCounter() =>
        _assets.Instantiate(AssetPath.TrashCounter);
}