using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField, Min(1)] private int _health;
    [SerializeField, Min(0)] private int _damage;
    [SerializeField, Min(0.1f)] private float _speed;
    [SerializeField, Min(0f)] private float _pushForce;
    [SerializeField] private EnemyStateMachineConfig _stateMachineConfig;

    public int Health => _health;
    public int Damage => _damage;
    public float Speed => _speed;
    public float PushForce => _pushForce;
    public EnemyStateMachineConfig StateMachineConfig => _stateMachineConfig;
}
