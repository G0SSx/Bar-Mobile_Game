using Plugins.SimpleInput.Scripts;
using UnityEngine;

namespace _Code.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const KeyCode AttackButtonKeyCode = KeyCode.E;
        private const KeyCode SettingsButtonKeyCode = KeyCode.Escape;

        public abstract Vector2 Axis { get; }

        public bool IsInterationButtonUp() =>
            UnityEngine.Input.GetKeyUp(AttackButtonKeyCode);

        public bool IsSettingsButtonUp() =>
            UnityEngine.Input.GetKeyUp(SettingsButtonKeyCode);

        protected static Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}