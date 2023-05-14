using System.Collections.Generic;
using UnityEngine;

public class Plate : KitchenObject
{
    [field:SerializeField] public PlateUIHandler UiHandler { get; private set; }

    [SerializeField] private Transform _kitchenObjectParent;

    private const int MaxIngredientAmount = 5;

    private Dictionary<KitchenObjectType, KitchenObject> _ingredients;

    private void Awake() => 
        _ingredients = new Dictionary<KitchenObjectType, KitchenObject>(MaxIngredientAmount);

    public KitchenObjectType[] GetIngredientsByType()
    {
        KitchenObjectType[] ingredients = new KitchenObjectType[_ingredients.Count];
        int index = 0;

        foreach(KitchenObject kitchenObject in _ingredients.Values)
        {
            ingredients[index] = kitchenObject.Type;
            index++;
        }

        return ingredients;
    }

    public bool CanKitchenObjectBeTaken(KitchenObject kitchenObject)
    {
        if (kitchenObject == null)
            return false;

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
        UiHandler.AddIngredientOfType(kitchenObject.Type);
    }
}