using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PlayerConfig _playerConfig;

    private void Awake()
    {
        _player.Initialize(_playerConfig);
    }
}
