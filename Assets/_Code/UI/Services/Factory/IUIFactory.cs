using UnityEngine;

namespace _Code.UI.Services.Factory
{
    public interface IUIFactory
    {
        Transform UIRoot { get; }

        void CreateUIRoot();
        void CreateHud();
        GameObject CreateIconObject(Sprite icon);
    }
}