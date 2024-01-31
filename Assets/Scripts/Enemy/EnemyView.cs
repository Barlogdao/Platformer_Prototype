using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour
{
    private static readonly int s_idle = Animator.StringToHash("Idle");
    private static readonly int s_run = Animator.StringToHash("Run");
    
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

}
