using UnityEngine;

namespace _Code.Infrastructure.Services.Input
{
    public class StandaloneInput : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = SimpleInputAxis();

                if (axis == Vector2.zero)
                    axis = VectorAxis();

                return axis.normalized;
            }
        }

        private static Vector2 VectorAxis() =>
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}