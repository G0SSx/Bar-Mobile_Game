using System.Collections.Generic;
using UnityEngine;

public class Plate : KitchenObject
{
    [SerializeField] private Transform _kitchenObjectParent;

    private const int MaxIngredientAmount = 5;

    private Dictionary<KitchenObjectType, KitchenObject> _ingredients;

    private void Awake() => 
        _ingredients = new Dictionary<KitchenObjectType, KitchenObject>(MaxIngredientAmount);

    public bool CanKitchenObjectBeTaken(KitchenObject kitchenObject)
    {
        if (kitchenObject == null)
        {
            Debug.Log("Object is null!");
            return false;
        }

        if (kitchenObject.IsCooked && _ingredients.ContainsKey(kitchenObject.Type) == false)
            return true;

        return false;
    }

    public void TakeKitchenObject(KitchenObject kitchenObject)
    {
        if (_ingredients.ContainsKey(kitchenObject.Type))
            return;

        kitchenObject.HasBeenTaken?.Invoke();
        _ingredients.Add(kitchenObject.Type, kitchenObject);
        kitchenObject.SetParent(_kitchenObjectParent);
    }
}