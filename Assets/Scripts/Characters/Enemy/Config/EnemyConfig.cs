using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/Config")]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField, Min(1)] public int Health { get; private set; }
    [field: SerializeField, Min(0)] public int Damage { get; private set; }
    [field: SerializeField, Min(0.1f)] public float Speed { get; private set; }
    [field: SerializeField, Min(0f)] public float PushForce { get; private set; }
    [field: SerializeField] public EnemyStateMachineConfig StateMachineConfig { get; private set; }
}
