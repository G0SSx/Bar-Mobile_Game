using _Code.KitchenObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Code.Configs
{
    [CreateAssetMenu(fileName = "KitchenObject", menuName = "Configs/Kitchen Object")]
    public class KitchenObjectConfig : ScriptableObject
    {
        [FormerlySerializedAs("Sprite")]
        public Sprite Icon;
        public KitchenObjectType Type;
        public KitchenObject Prefab;
        public bool IsCuttable;
        public bool IsCooked;
    }
}