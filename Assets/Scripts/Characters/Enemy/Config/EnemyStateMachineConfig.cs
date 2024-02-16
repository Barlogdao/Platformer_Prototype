using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/SMConfig")]
public class EnemyStateMachineConfig : ScriptableObject
{
    [field: SerializeField, Min(1)] public float ChaseDistance { get; private set; }
    [field: SerializeField, Min(0.1f)] public float WaitDuration { get; private set; }
}