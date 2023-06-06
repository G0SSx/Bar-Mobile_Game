using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField, Range(0.1f, 0.5f)] public float MovementThreashold { get; private set; } = 0.1f;
    [field: SerializeField, Range(1, 4)] public float MoveSpeed { get; private set; } = 2;
    [field: SerializeField, Range(7, 25)] public float RotationSpeed { get; private set; } = 10f;
    [field: SerializeField, Range(1, 2)] public float InteractionDistance { get; private set; } = 1.75f;
}