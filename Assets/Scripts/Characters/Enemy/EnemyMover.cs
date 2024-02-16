using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private ObstacleDetector _obstacleDetector;
    [SerializeField] private PlatformEndDetector _platformEndDetector;

    private float _speed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    public bool IsNeedChangeDirection => IsObstacleDetected || IsPlatformEndDetected;
    public bool IsObstacleDetected => _obstacleDetector.IsDetected();
    public bool IsPlatformEndDetected => _platformEndDetector.IsDetected();

    public void Initialize(float speed)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = transform.right;
        _speed = speed;
    }

    public void Move()
    {
        Vector2 velocity = _speed * _direction;
        velocity.y = _rigidbody2D.velocity.y;

        _rigidbody2D.velocity = velocity;
    }

    public void MoveTo(Transform target)
    {
        ChangeDirection(target);
        Move();
    }

    public void StopMove()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void ChangeDirection()
    {
        _direction = -_direction;

        CheckDirection();
    }

    public void ChangeDirection(Transform target)
    {
        float horizontalDirection = Mathf.Sign(target.position.x - transform.position.x);
        _direction = new Vector2(horizontalDirection, 0);

        CheckDirection();
    }

    private void CheckDirection()
    {
        if (_direction.x < 0)
            TurnLeft();
        else if (_direction.x > 0)
            TurnRight();
    }

    private void TurnLeft() => transform.rotation = Quaternion.Euler(0f, 180f, 0f);

    private void TurnRight() => transform.rotation = Quaternion.identity;
}