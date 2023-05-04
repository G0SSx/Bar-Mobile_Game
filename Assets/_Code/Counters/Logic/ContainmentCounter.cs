using UnityEngine;
using System;

public abstract class ContainmentCounter : BaseCounter
{
    [SerializeField] private Transform _kitchenObjectParent;

    protected KitchenObject kitchenObject { get; private set; }

    protected KitchenObject ReturnKitchenObject()
    {
        KitchenObject objectToReturn = kitchenObject;
        kitchenObject = null;
        return objectToReturn;
    }

    protected KitchenObject TakeKitchenObject(KitchenObject kitchenObject)
    {
        if (kitchenObject == null)
            throw new ArgumentNullException();

        kitchenObject.HasBeenTaken?.Invoke();
        this.kitchenObject = kitchenObject;
        this.kitchenObject.SetParent(_kitchenObjectParent);
        return null;
    }
}