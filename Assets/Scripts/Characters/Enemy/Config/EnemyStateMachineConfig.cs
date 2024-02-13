using UnityEngine;


[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/SMConfig")]
public class EnemyStateMachineConfig : ScriptableObject
{
    [SerializeField, Min(1)] private float _chaseDistance;
    [SerializeField, Min(0.1f)] private float _waitDuration;

    public float ChaseDistance => _chaseDistance;
    public float WaitDuration => _waitDuration;
}