using _Code.Configs;
using _Code.Counters.Logic;
using _Code.Counters.SoundLogic;
using _Code.Data;
using _Code.KitchenObjects;
using _Code.KitchenObjects.PlateLogic;
using _Code.UI.Elements;
using _Code.UI.Services.Factory;
using UnityEngine;
using Zenject;

namespace _Code.Counters
{
    public class DeliveryCounter : BaseCounter
    {
        [SerializeField] private InteractAndDenySoundCounter _sounds;
        [SerializeField] private RecipeConfigs _recipeConfigs;
        [SerializeField] private RecipeUIHandler _recipeUI;

        private IPersistentProgressService _progress;
        private RecipeData _recipeData;
        private IUIFactory _factory;

        [Inject]
        private void Construct(IPersistentProgressService progress, IUIFactory factory)
        {
            _progress = progress;
            _factory = factory;
        }

        private void Start() =>
            GetNewRecipe();

        public override KitchenObject Interact(KitchenObject playersObject)
        {
            if (playersObject == null || playersObject is not Plate)
                return DenyRecipe();

            if (IngredientsMatch(playersObject as Plate))
            {
                AcceptOrder(playersObject);
                GetNewRecipe();
            }

            return DenyRecipe();
        }

        private void AcceptOrder(KitchenObject playersObject)
        {
            _progress.Progress.Balance.AddMoney(_recipeData.Ingredients.Length);
            _sounds.PlayInteractSound();
            playersObject.ObjectDeleted?.Invoke();
            _recipeUI.RecipeDelivered();
        }

        private void GetNewRecipe()
        {
            _recipeData = GetRandomRecipe();
            _recipeUI.SetTitle(_recipeData.Title);

            /*foreach (KitchenObjectConfig ingredient in _recipeData.Ingredients)
            {
                GameObject iconObject = _factory.CreateIconObject(ingredient.Icon);
                _recipeUI.AddIconObject(iconObject);
            }*/
        }

        private bool IngredientsMatch(Plate plate)
        {
            KitchenObjectType[] playersIngredients = plate.GetIngredientsByType();

            if (playersIngredients.Length != _recipeData.Ingredients.Length)
                return false;

            if (IngredientsMatch(playersIngredients))
                return true;

            return false;
        }

        private RecipeData GetRandomRecipe()
        {
            int randomIndex = Random.Range(0, _recipeConfigs.Recipes.Length);
            return _recipeConfigs.Recipes[randomIndex];
        }

        private KitchenObject DenyRecipe()
        {
            _sounds.PlayDenySound();
            return null;
        }

        private bool IngredientsMatch(KitchenObjectType[] playersIngredients)
        {
            int matchedIngredietnsAmount = 0;

            foreach (KitchenObjectType kitchenObjectType in playersIngredients)
            {
                foreach (KitchenObjectConfig recipeIngredients in _recipeData.Ingredients)
                {
                    if (kitchenObjectType == recipeIngredients.Type)
                    {
                        matchedIngredietnsAmount++;
                        break;
                    }
                }
            }

            return matchedIngredietnsAmount == _recipeData.Ingredients.Length;
        }
    }
}