using System.Collections;
using System.Linq;
using UnityEngine;

public class Vampirism : Spell
{
    [SerializeField] private float _radius;
    [SerializeField] private float _duration;
    [SerializeField] private int _drainAmountPerSecond;
    [SerializeField] private LayerMask _targetLayer;

    [SerializeField] private Transform _casterTransform;
    [SerializeField] private PlayerHealth _casterHealth;
    [SerializeField] private ParticleSystem _spellVisual;

    private readonly float _tickDuration = 1f;
    private Coroutine _drainLife;

    private void Awake()
    {
        ParticleSystem.MainModule particleSystem = _spellVisual.main;
        particleSystem.startSize = _radius * 2;
    }

    public override void Cast()
    {
        StopCast();
        _drainLife = StartCoroutine(DrainLifeRoutine());
    }

    public override void StopCast()
    {
        if (_drainLife != null)
            StopCoroutine(_drainLife);
    }

    private IEnumerator DrainLifeRoutine()
    {
        WaitForSeconds _interval = new WaitForSeconds(_tickDuration);
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            Collider2D target = GetClosestTarget();

            if (target != null && target.TryGetComponent(out IDamagable damagable))
            {
                DrainLife(damagable);
            }

            _spellVisual.Play();

            elapsedTime += _tickDuration;

            yield return _interval;
        }

        InvokeCasedEvent();
    }

    private Collider2D GetClosestTarget()
    {
        Collider2D target = Physics2D.OverlapCircleAll(_casterTransform.position, _radius, _targetLayer)
            .Where(t => t.TryGetComponent(out IDamagable damagable) && damagable.IsAlive)
            .OrderBy(t => (t.transform.position - _casterTransform.position).sqrMagnitude)
            .FirstOrDefault();

        return target;
    }

    private void DrainLife(IDamagable damagable)
    {
        damagable.TakeDamage(_drainAmountPerSecond);
        _casterHealth.Heal(_drainAmountPerSecond);
    }

    private void OnValidate()
    {
        if (_casterTransform != null && _spellVisual != null)
        {
            _spellVisual.transform.position = _casterTransform.position;
        }
    }
}
