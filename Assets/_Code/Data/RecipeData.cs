using System;
using _Code.Configs;

namespace _Code.Data
{
    [Serializable]
    public class RecipeData
    {
        public string Title;
        public KitchenObjectConfig[] Ingredients;
    }
}