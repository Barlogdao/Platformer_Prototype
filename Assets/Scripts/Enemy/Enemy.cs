using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private const string HorizontalSpeed = "HorizontalSpeed";

    [SerializeField] private float _speed;
    [SerializeField] BoxCollider2D _boxCollider;
    [SerializeField] ObstacleChecker _obstacleChecker;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = transform.right;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed,_rigidbody2D.velocity.y);
        _animator.SetFloat(HorizontalSpeed, Mathf.Abs(_direction.x));

        if (_obstacleChecker.IsTouches)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        Vector2 changedScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        transform.localScale = changedScale;
        _direction = -_direction;         
    }
}
