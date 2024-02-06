using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Chest : Interactable
{
    private const string OpenChest = nameof(OpenChest);

    [SerializeField] private int _coinAmount;
    [SerializeField] private float _spawnCooldown;
    [SerializeField, Min(1)] private float _verticalSpawnForce;
    [SerializeField] ParticleSystem _particles;

    private Animator _animator;
    private CoinPull _coinPull;

    protected override void OnAwake()
    {
        base.OnAwake();
        _animator = GetComponent<Animator>();
    }

    public void Initialize(CoinPull coinPull)
    {
        _coinPull = coinPull;
    }

    protected override void OnInteract()
    {
        _animator.SetTrigger(OpenChest);
        StartCoroutine(SpawnCoins());
    }

    protected override void OnInteractorEnter()
    {
        base.OnInteractorEnter();

        _particles.Play();
    }

    protected override void OnInteractorExit()
    {
        base.OnInteractorExit();

        _particles.Stop();
    }

    private IEnumerator SpawnCoins()
    {
        WaitForSeconds cooldown = new WaitForSeconds (_spawnCooldown);

        for (int i = 0; i < _coinAmount; i++)
        {
            Coin coin = _coinPull.Get(transform.position);

            coin.AddForce(GetCoinVelocity());

            yield return cooldown;
        }
    }

    private Vector2 GetCoinVelocity()
    {
        return new Vector2(Random.value, 1f * _verticalSpawnForce);
    }
}
