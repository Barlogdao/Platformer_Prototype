using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerAnimatorEvents))]
public class PlayerView : MonoBehaviour
{
    private static readonly int s_idle = Animator.StringToHash("Idle");
    private static readonly int s_run = Animator.StringToHash("Run");
    private static readonly int s_jump = Animator.StringToHash("Jump");
    private static readonly int s_fall = Animator.StringToHash("Fall");
    private static readonly int s_attack = Animator.StringToHash("Attack");
    private static readonly int s_hit = Animator.StringToHash("Hit");
    private static readonly int s_death = Animator.StringToHash("Death");
    private static readonly int s_airAttack = Animator.StringToHash("AirAttack");

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartIdle() => _animator.Play(s_idle);

    public void StartRun() => _animator.Play(s_run);

    public void StartJump() => _animator.Play(s_jump);

    public void StartFall() => _animator.Play(s_fall);

    public void StartDeath() => _animator.Play(s_death);

    public void StartAttack() => _animator.Play(s_attack);

    public void StartAirAttack() => _animator.Play(s_airAttack);

    public void StartHit() => _animator.Play(s_hit);
}