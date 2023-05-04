using UnityEngine;

public static class VectorExtensions
{
    public static bool Greater(this Vector2 vector, float value) =>
        Mathf.Abs(vector.x) > value || Mathf.Abs(vector.y) > value;

    public static Vector3 AddY(this Vector3 vector, float value) =>
        new Vector3(vector.x, vector.y + value, vector.z);
    
    public static Vector3 SubtractY(this Vector3 vector, float value) =>
        new Vector3(vector.x, vector.y - value, vector.z);
}