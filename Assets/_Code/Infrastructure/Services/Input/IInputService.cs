using UnityEngine;

public interface IInputService
{
    Vector2 Axis { get; }

    bool IsInterationButtonUp();
    bool IsSettingsButtonUp();
}