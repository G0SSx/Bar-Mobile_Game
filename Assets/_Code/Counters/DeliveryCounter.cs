using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DeliveryCounter : BaseCounter
{
    public Action<int> OnOrderAccepted;

    [SerializeField] private RecipeConfigs _recipeConfigs;
    [SerializeField] private Recipe _recipe;
    [SerializeField] private GameObject _orderIconObject;

    private IconsFactory _iconsFactory;
    private RecipeData _recipeData;

    [Inject]
    private void Construct(IconsFactory iconsFactory)
    {
        _iconsFactory = iconsFactory;
    }

    private void Start()
    {
        RequestRecipe();
    }

    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (playersObject is Plate plate)
        {
            if (IngredientsMatches(plate))
            {
                AcceptOrder(playersObject);
            }
        }
        return null;
    }

    private void RequestRecipe()
    {
        _recipeData = GetRandomRecipe();
        _recipe.SetTitle(_recipeData.Title);

        foreach (KitchenObjectConfig ingredient in _recipeData.Ingredients)
        {
            GameObject orderPrefab = Instantiate(_orderIconObject);
            Sprite iconSprite = _iconsFactory.GetSpriteOfType(ingredient.Type);
            orderPrefab.GetComponent<Image>().sprite = iconSprite;
            _recipe.AddIconToRecipe(orderPrefab);
        }
    }

    private RecipeData GetRandomRecipe()
    {
        int randomIndex = UnityEngine.Random.Range(0, _recipeConfigs.Recipes.Length);
        return _recipeConfigs.Recipes[randomIndex];
    }

    private void AcceptOrder(KitchenObject playersObject)
    {
        PlayInteractionSound();

        playersObject.DeleteObject?.Invoke();
        Destroy(playersObject.gameObject);
        OnOrderAccepted?.Invoke(_recipeData.Ingredients.Length);
        _recipe.RecipeDelivered();
        RequestRecipe();
    }

    private bool IngredientsMatches(Plate plate)
    {
        KitchenObjectType[] playersIngredients = plate.GetIngredientsByType();

        if (playersIngredients.Length != _recipeData.Ingredients.Length)
            return false;

        int ingredientsMatched = GetMatchedIngredientsAmount(playersIngredients);

        if (ingredientsMatched == _recipeData.Ingredients.Length)
            return true;

        return false;
    }

    private int GetMatchedIngredientsAmount(KitchenObjectType[] playersIngredients)
    {
        int ingredientsMatched = 0;

        for (int i = 0; i < playersIngredients.Length; i++)
        {
            foreach (KitchenObjectConfig recipeIngredients in _recipeData.Ingredients)
            {
                if (playersIngredients[i] == recipeIngredients.Type)
                {
                    ingredientsMatched++;
                    break;
                }
            }
        }

        return ingredientsMatched;
    }
}