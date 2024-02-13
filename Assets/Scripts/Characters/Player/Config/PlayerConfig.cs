using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/Config")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField, Min(0)] private int _startMoney;
    [SerializeField, Min(1)] private int _health;
    [SerializeField, Min(0)] private int _damage;
    [SerializeField, Min(0.1f)] private float _speed;
    [SerializeField, Min(1f)] private float _jumpForce;
    [SerializeField, Min(0f)] private float _pushForce;

    public int StartMoney => _startMoney;
    public int Health => _health;
    public int Damage => _damage;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public float PushForce => _pushForce;
}