using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private Transform _objectParent;
    
    private KitchenObject _kitchenObject;

    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (PlayerAndCounterAreFull(playersObject) || BothObjectsAreEmpty(playersObject))
            return null;

        if (_kitchenObject == null)
            TakeKitchenObject(playersObject);
        else
            return GiveKitchenObjectToPlayer();

        return null;
    }

    private bool PlayerAndCounterAreFull(KitchenObject playersObject) =>
        playersObject != null && _kitchenObject != null;

    private bool BothObjectsAreEmpty(KitchenObject playersObject) =>
        playersObject == null && _kitchenObject == null;

    private KitchenObject GiveKitchenObjectToPlayer()
    {
        KitchenObject objectToReturn = _kitchenObject;
        _kitchenObject = null;
        return objectToReturn;
    }

    private void TakeKitchenObject(KitchenObject kitchenObject) 
    {
        kitchenObject.HasBeenTaken();
        _kitchenObject = kitchenObject;
        _kitchenObject.SetParent(_objectParent);
    }
}