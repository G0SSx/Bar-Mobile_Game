using UnityEngine;

namespace _Code.KitchenObjects.Factory
{
    public interface IKitchenObjectsFactory
    {
        Glass CreateGlass();
        KitchenObject CreateKitchenObject(KitchenObjectType type);
        KitchenObject CreateSlicedKitchenObject(KitchenObjectType type);
        Sprite GetSpriteByType(KitchenObjectType type);
    }
}