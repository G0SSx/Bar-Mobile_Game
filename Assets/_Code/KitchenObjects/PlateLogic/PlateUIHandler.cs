using UnityEngine;

public class PlateUIHandler : MonoBehaviour
{
    [SerializeField] private Transform _firstRow;
    [SerializeField] private Transform _secondRow;

    private int _ingredientsCount;
    private IconsFactory _factory;

    public void Construct(IconsFactory factory)
    {
        _factory = factory;
    }

    public void AddIngredientOfType(KitchenObjectType type)
    {
        GameObject iconObject = _factory.CreateIconObject(type);

        if (_ingredientsCount < 3)
            SetIconsParent(iconObject.transform, _firstRow);
        else
            SetIconsParent(iconObject.transform, _secondRow);

        _ingredientsCount++;
    }

    private void SetIconsParent(Transform icon, Transform iconsParent)
    {
        icon.SetParent(iconsParent);
        icon.position = iconsParent.position;
        icon.rotation = iconsParent.rotation;
    }
}