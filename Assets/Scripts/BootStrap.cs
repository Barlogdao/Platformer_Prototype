using System;
using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerConfig _playerConfig;

    [Space(30)]
    [SerializeField] private List<Chest> _chests;
    [SerializeField] private List<Transform> _coinPoints;

    [Space(30)]
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _coinContainer;

    private CoinPull _coinPull;

    private void Awake()
    {
        _player.Initialize(_playerConfig);

        _coinPull = new CoinPull(_coinPrefab, _coinContainer);

        InitCoins();
        InitChests();
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
}
