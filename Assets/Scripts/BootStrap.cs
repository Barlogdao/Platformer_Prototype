using System;
using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerConfig _playerConfig;
    [Space(30)]
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private EnemyConfig _enemyConfig;
    [Space(30)]
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _coinContainer;
    [SerializeField] private List<Transform> _coinPoints;
    [Space(30)]
    [SerializeField] private List<Chest> _chests;

    private CoinPull _coinPull;

    private void Awake()
    {
        _player.Initialize(_playerConfig);

        InitEnemies();

        _coinPull = new CoinPull(_coinPrefab, _coinContainer);
        InitCoins();
        InitChests();
    }

    private void InitEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Initialize(_enemyConfig);
        }
    }

    private void InitCoins()
    {
        foreach (Transform point in _coinPoints)
        {
            _coinPull.Get(point.position);
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