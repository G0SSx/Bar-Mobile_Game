using UnityEngine;

namespace _Code.Infrastructure.Services.Input
{
    public class MobileInput : InputService
    {
        public override Vector2 Axis => SimpleInputAxis().normalized;
    }
}