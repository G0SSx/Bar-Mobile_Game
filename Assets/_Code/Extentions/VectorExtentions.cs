using UnityEngine;

public static class VectorExtentions
{
    public static bool Greater(this Vector2 vector, float value) =>
        Mathf.Abs(vector.x) > value || Mathf.Abs(vector.y) > value;
}