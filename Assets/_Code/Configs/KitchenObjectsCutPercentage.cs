using UnityEngine;

namespace _Code.Configs
{
    [CreateAssetMenu(fileName = "CuttableObjectsConfig", menuName = "Configs/CuttableObjectsConfig")]
    public class KitchenObjectsCutPercentage : ScriptableObject
    {
        [field:SerializeField] public int TomatoCutPercent { get; private set; } = 34;
        [field: SerializeField] public int CheeseCutPercent { get; private set; } = 27;
        [field: SerializeField] public int CabbageCutPercent { get; private set; } = 20;
    }
}