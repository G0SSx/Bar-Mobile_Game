using UnityEngine;

[CreateAssetMenu(fileName = "KitchenObject", menuName = "Configs/Kitchen Object")]
public class KitchenObjectConfig : ScriptableObject
{
    [field: SerializeField] public KitchenObjectType Type { get; private set; }
    [field: SerializeField] public KitchenObject Prefab { get; private set; }
    [field: SerializeField] public bool IsCuttable { get; private set; }
    [field: SerializeField] public bool IsCooked { get; private set; }
}