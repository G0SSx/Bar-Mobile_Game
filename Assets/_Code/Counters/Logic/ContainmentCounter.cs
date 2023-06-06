using UnityEngine;
using System;

public abstract class ContainmentCounter : BaseCounter
{
    [SerializeField] private Transform _kitchenObjectParent;
    [SerializeField] private TakeAndGiveSoundCounter _counterSounds;

    protected KitchenObject kitchenObject { get; private set; }

    protected virtual KitchenObject ReturnKitchenObject()
    {
        _counterSounds.PlayTakeSound();
        KitchenObject objectToReturn = kitchenObject;
        kitchenObject = null;
        return objectToReturn;
    }

    protected virtual void TakeKitchenObject(KitchenObject kitchenObject)
    {
        if (kitchenObject == null)
            throw new ArgumentNullException();

        _counterSounds.PlayTakeSound();
        kitchenObject.HasBeenTaken?.Invoke();
        this.kitchenObject = kitchenObject;
        this.kitchenObject.SetParent(_kitchenObjectParent);
    }
}