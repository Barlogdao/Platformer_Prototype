using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerView : MonoBehaviour
{
    private const string HorizontalSpeed = "HorizontalSpeed";
    private const string IsGrounded = "IsGrounded";
    private const string VerticalSpeed = "VerticalSpeed";

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetHorizontalSpeed(float speed)
    {
        _animator.SetFloat(HorizontalSpeed, Mathf.Abs(speed));
        CheckDirection(speed);
    }

    public void SetVerticalSpeed(float speed)
    {
        _animator.SetFloat(VerticalSpeed, speed);
    }

    public void GroundCheck(bool isGrounded)
    {
        _animator.SetBool(IsGrounded, isGrounded);
    }

    private void CheckDirection(float horizontalDirection)
    {
        _spriteRenderer.flipX = horizontalDirection < 0f ? true : false;
    }
}
