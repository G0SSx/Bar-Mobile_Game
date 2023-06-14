using _Code.Data;
using UnityEngine;

namespace _Code.Configs
{
    [CreateAssetMenu(fileName = "RecipeConfigs", menuName = "Configs/Recipes")]
    public class RecipeConfigs : ScriptableObject
    {
        [field:SerializeField] public RecipeData[] Recipes { get; private set; }
    }
}