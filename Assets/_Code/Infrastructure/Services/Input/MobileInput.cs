using UnityEngine;

public class MobileInput : InputService
{
    public override Vector2 Axis => SimpleInputAxis().normalized;
}