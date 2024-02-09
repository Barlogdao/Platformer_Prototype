using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/Config")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField, Min(0)] private int _startMoney;
    [SerializeField, Min(1)] private int _health;
    [SerializeField, Min(0)] private int _damage;

    public int StartMoney => _startMoney;
    public int Health => _health;
    public int Damage => _damage;
}