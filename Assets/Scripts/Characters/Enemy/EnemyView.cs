using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyAnimatorEvents))]
public class EnemyView : MonoBehaviour
{
    private static readonly int s_idle = Animator.StringToHash("Idle");
    private static readonly int s_run = Animator.StringToHash("Run");
    private static readonly int s_attack = Animator.StringToHash("Attack");
    private static readonly int s_death = Animator.StringToHash("Death");

    [SerializeField] private Color _hitColor;
    [SerializeField] private float _hitDuration;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private IDamagable _damagable;
    private Color _originColor;

    public void Initialize(IDamagable damagable)
    {
        _animator = GetComponent<Animator>();
        _damagable = damagable;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originColor = _spriteRenderer.color;

        _damagable.Hitted += OnHitted;
    }

    private void OnDestroy()
    {
        _damagable.Hitted -= OnHitted;
    }

    public void StartIdle() => _animator.Play(s_idle);

    public void StartRun() => _animator.Play(s_run);

    public void StartDeath() => _animator.Play(s_death);

    public void StartAttack() => _animator.Play(s_attack);

    private void OnHitted()
    {
        _spriteRenderer.color = _hitColor;
        _spriteRenderer.DOColor(_originColor, _hitDuration);
    }
}