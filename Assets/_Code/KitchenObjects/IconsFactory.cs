using UnityEngine;
using UnityEngine.UI;

public class IconsFactory
{
    private readonly GameObject _emptyIconPrefab;
    private readonly IconsStorage _storage;

    public IconsFactory(IconsStorage storage, GameObject emptyIconPrefab)
    {
        _storage = storage;
        _emptyIconPrefab = emptyIconPrefab;
    }

    public GameObject CreateIconObject(KitchenObjectType type)
    {
        GameObject iconObject = Object.Instantiate(_emptyIconPrefab);
        Image image = iconObject.GetComponent<Image>();
        image.sprite = GetSpriteOfType(type);

        return iconObject;
    }

    public Sprite GetSpriteOfType(KitchenObjectType type)
    {
        switch (type)
        {
            case KitchenObjectType.Tomato:
                return _storage.TomatoSlicedIcon;
            case KitchenObjectType.Bread:
                return _storage.BreadIcon;
            case KitchenObjectType.Cabbage:
                return _storage.CabbageSlicedIcon;
            case KitchenObjectType.Cheese:
                return _storage.CheeseSlicedIcon;
            case KitchenObjectType.MeatCooked:
                return _storage.CookedMeatIcon;
            default:
                Debug.LogError($"The icon of type {type} wasn't found!");
                return null;
        }
    }
}
