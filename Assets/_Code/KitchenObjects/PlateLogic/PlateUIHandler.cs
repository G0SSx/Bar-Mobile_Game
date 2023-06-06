using UnityEngine;
using Zenject;

public class PlateUIHandler : MonoBehaviour
{
    [SerializeField] private Transform _firstRow;
    [SerializeField] private Transform _secondRow;

    private const int FirstRowMaxIconsAmount = 3;

    private int _ingredientsCount;
    private IUIFactory _factory;

    [Inject]
    private void Contruct(IUIFactory factory) => 
        _factory = factory;
    
    public void AddIngredientOfType(Sprite icon)
    {
        CreateIngredientObject(icon);
        _ingredientsCount++;
    }

    private void CreateIngredientObject(Sprite icon)
    {
        GameObject iconObject = _factory.CreateIconObject(icon);
        iconObject.name = $"Ingredient {_ingredientsCount}";

        SetIconsParent(iconObject.transform, _ingredientsCount < FirstRowMaxIconsAmount
            ? _firstRow
            : _secondRow);
    }

    private void SetIconsParent(Transform icon, Transform iconsParent)
    {
        icon.SetParent(iconsParent);
        icon.position = iconsParent.position;
        icon.rotation = iconsParent.rotation;
    }
}