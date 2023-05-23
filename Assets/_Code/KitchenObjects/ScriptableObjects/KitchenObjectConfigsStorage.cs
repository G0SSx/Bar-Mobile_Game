using UnityEngine;

[CreateAssetMenu(fileName = "configStorage", menuName = "Configs/ConfigStorage")]
public class KitchenObjectConfigsStorage : ScriptableObject
{
    [field:SerializeField] public KitchenObjectConfig UncookedMeatConfig { get; private set; }
    [field:SerializeField] public KitchenObjectConfig CookedMeatConfig { get; private set; }
    [field:SerializeField] public KitchenObjectConfig BurnedMeatConfig { get; private set; }
    [field:SerializeField] public KitchenObjectConfig Bread { get; private set; }
    [field:SerializeField] public KitchenObjectConfig Tomato { get; private set; }
    [field:SerializeField] public KitchenObjectConfig Cheese { get; private set; }
    [field:SerializeField] public KitchenObjectConfig Plate { get; private set; }
    [field:SerializeField] public KitchenObjectConfig Cabbage { get; private set; }
    [field:SerializeField] public KitchenObjectConfig CabbageSliced { get; private set; }
    [field:SerializeField] public KitchenObjectConfig TomatoSliced { get; private set; }
    [field:SerializeField] public KitchenObjectConfig CheeseSliced { get; private set; }
}