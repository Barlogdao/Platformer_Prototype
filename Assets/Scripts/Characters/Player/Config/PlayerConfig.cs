using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/Config")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField, Min(0)] public int StartMoney { get; private set; }
    [field: SerializeField, Min(1)] public int Health { get; private set; }
    [field: SerializeField, Min(0)] public int Damage { get; private set; }
    [field: SerializeField, Min(0.1f)] public float Speed { get; private set; }
    [field: SerializeField, Min(1f)] public float JumpForce { get; private set; }
    [field: SerializeField, Min(0f)] public float PushForce { get; private set; }
}