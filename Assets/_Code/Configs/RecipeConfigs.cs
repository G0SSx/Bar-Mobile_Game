using UnityEngine;

[CreateAssetMenu(fileName = "RecipeConfigs", menuName = "Configs/Recipes")]
public class RecipeConfigs : ScriptableObject
{
    [field:SerializeField] public RecipeData[] Recipes { get; private set; }
}