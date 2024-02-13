using UnityEngine;
using UnityEngine.Pool;

public class CoinPull
{
    private readonly ObjectPool<Coin> _pull;

    private readonly Coin _prefab;
    private readonly int _defaultCapacity;
    private readonly Transform _parent;

    public CoinPull(Coin prefab, Transform parent)
    {
        _defaultCapacity = 20;
        _prefab = prefab;
        _parent = parent;
        _pull = new ObjectPool<Coin>(Create, OnGet, OnRelease, OnDestroy, defaultCapacity: _defaultCapacity);
    }

    public Coin Get(Vector2 spawnPosition)
    {
        Coin coin = _pull.Get();
        coin.transform.position = spawnPosition;
        return coin;
    }

    public void Release(Coin coin)
    {
        _pull.Release(coin);
    }

    private Coin Create()
    {
        Coin coin = UnityEngine.Object.Instantiate(_prefab, _parent);
        coin.Initialize(this);

        coin.gameObject.SetActive(false);

        return coin;
    }

    private void OnRelease(Coin coin) => coin.gameObject.SetActive(false);

    private void OnGet(Coin coin) => coin.gameObject.SetActive(true);

    private void OnDestroy(Coin coin) => UnityEngine.Object.Destroy(coin.gameObject);
}