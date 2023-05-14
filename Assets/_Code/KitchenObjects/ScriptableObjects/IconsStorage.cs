using UnityEngine;

[CreateAssetMenu(fileName = "IconsStorage", menuName = "Configs/IconsStorage")]
public class IconsStorage : ScriptableObject
{
    [field:SerializeField] public Sprite TomatoSlicedIcon { get; private set; }
    [field:SerializeField] public Sprite CheeseSlicedIcon { get; private set; }
    [field:SerializeField] public Sprite CabbageSlicedIcon { get; private set; }
    [field:SerializeField] public Sprite CookedMeatIcon { get; private set; }
    [field:SerializeField] public Sprite BreadIcon { get; private set; }
}