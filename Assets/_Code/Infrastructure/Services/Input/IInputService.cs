﻿using UnityEngine;

namespace _Code.Infrastructure.Services.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }

        bool IsInteractionButtonUp();
        bool IsSettingsButtonUp();
    }
}