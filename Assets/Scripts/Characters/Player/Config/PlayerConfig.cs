using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/Config")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField, Min(0)] private int _startMoney;

    public int StartMoney => _startMoney;
}