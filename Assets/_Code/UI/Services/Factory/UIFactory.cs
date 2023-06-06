using UnityEngine;
using UnityEngine.UI;

public class UIFactory : IUIFactory
{
    public Transform UIRoot { get; private set; }

    private readonly IAssets _assets;

    public UIFactory(IAssets assets) => 
        _assets = assets;

    public void CreateUIRoot() => 
        UIRoot = _assets.Instantiate(AssetPath.UIRoot).transform;

    public void CreateHud() => 
        _assets.InstantiateWithZenject(AssetPath.Hud, UIRoot);

    public GameObject CreateIconObject(Sprite icon)
    {
        GameObject iconObject = _assets.Instantiate(AssetPath.IconObject);

        iconObject.GetComponent<Image>()
            .sprite = icon;

        return iconObject;
    }
}