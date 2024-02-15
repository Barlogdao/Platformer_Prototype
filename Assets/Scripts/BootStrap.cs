using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [Header ("Player")]
    [SerializeField] private Player _player;
    [SerializeField] private PlayerConfig _playerConfig;
    [Header("Enemies")]
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private EnemyConfig _enemyConfig;
    [Header("Coins")]
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _coinContainer;
    [SerializeField] private List<Chest> _chests;

    private CoinPull _coinPull;

    private void Awake()
    {
        _player.Initialize(_playerConfig);

        InitEnemies();

        _coinPull = new CoinPull(_coinPrefab, _coinContainer);
        InitChests();
    }

    private void InitEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Initialize(_enemyConfig);
        }
    }

    private void InitChests()
    {
        foreach (Chest chest in _chests)
        {
            chest.Initialize(_coinPull);
        }
    }

    [ContextMenu("Update Enemy List")]
    private void UpdateEnemies()
    {
        _enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
    }
}