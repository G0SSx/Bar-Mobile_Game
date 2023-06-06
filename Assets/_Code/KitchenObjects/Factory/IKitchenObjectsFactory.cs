using UnityEngine;

public interface IKitchenObjectsFactory
{
    KitchenObject CreateKitchenObject(KitchenObjectType type);
    KitchenObject CreateSlicedKitchenObject(KitchenObjectType type);
    Sprite GetSpriteByType(KitchenObjectType type);
}