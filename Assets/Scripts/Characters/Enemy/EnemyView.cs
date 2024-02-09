using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyAnimatorEvents))]
public class EnemyView : MonoBehaviour
{
    private static readonly int s_idle = Animator.StringToHash("Idle");
    private static readonly int s_run = Animator.StringToHash("Run");
    private static readonly int s_attack = Animator.StringToHash("Attack");
    private static readonly int s_death = Animator.StringToHash("Death");

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartIdle() => _animator.Play(s_idle);
    public void StartRun() => _animator.Play(s_run);
    public void StartDeath() => _animator.Play(s_death);
    public void StartAttack() => _animator.Play(s_attack);
}