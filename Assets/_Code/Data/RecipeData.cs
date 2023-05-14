using System;
using UnityEngine;

[Serializable]
public class RecipeData
{
    [field: SerializeField] public string Title;
    [field: SerializeField] public KitchenObjectConfig[] Ingredients;
}