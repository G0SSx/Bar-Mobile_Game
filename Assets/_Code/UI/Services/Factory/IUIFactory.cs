using UnityEngine;

public interface IUIFactory
{
    Transform UIRoot { get; }

    void CreateUIRoot();
    void CreateHud();
    GameObject CreateIconObject(Sprite icon);
}