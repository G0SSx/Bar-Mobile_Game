using UnityEngine;

public class KitchenObjectsFactory
{
    private KitchenObject _cabbagePrefab;
    private KitchenObject _meatPrefab;
    private KitchenObject _tomatoPrefab;
    private KitchenObject _cheesePrefab;

    public KitchenObjectsFactory(KitchenObject cabbagePrefab, KitchenObject meatPrefab, 
        KitchenObject tomatoPrefab, KitchenObject cheesePrefab)
    {
        _cabbagePrefab = cabbagePrefab;
        _meatPrefab = meatPrefab;
        _tomatoPrefab = tomatoPrefab;
        _cheesePrefab = cheesePrefab;
    }

    public KitchenObject CreateKitchenObject(KitchenObjectType type, Transform objectParent)
    {
        KitchenObject kitchenObject = null;

        switch (type)
        {
            case KitchenObjectType.Tomato:
                kitchenObject = Object.Instantiate(_tomatoPrefab);
                break;
            case KitchenObjectType.Meat:
                kitchenObject = Object.Instantiate(_meatPrefab);
                break;
            case KitchenObjectType.Cheese:
                kitchenObject = Object.Instantiate(_cheesePrefab);
                break;
            case KitchenObjectType.Cabbage:
                kitchenObject = Object.Instantiate(_cabbagePrefab);
                break;
        }

        if (kitchenObject != null)
        {
            kitchenObject.transform.SetParent(objectParent);
            kitchenObject.transform.position = objectParent.position;
            kitchenObject.transform.rotation = objectParent.rotation;
        }

        return kitchenObject;
    }
}