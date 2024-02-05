using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerView : MonoBehaviour
{
    private static readonly int s_idle = Animator.StringToHash("Idle");
    private static readonly int s_run = Animator.StringToHash("Run");
    private static readonly int s_jump = Animator.StringToHash("Jump");
    private static readonly int s_fall = Animator.StringToHash("Fall");

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartIdle()
    {
        _animator.Play(s_idle);
    }

    public void StartRun()
    {
        _animator.Play(s_run);
    }

    public void StartJump()
    {
        _animator.Play(s_jump);
    }

    public void StartFall()
    {
        _animator.Play(s_fall);
    }
}
