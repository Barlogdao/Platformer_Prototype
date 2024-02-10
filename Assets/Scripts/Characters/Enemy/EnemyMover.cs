using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ObstacleDetector _obstacleDetector;
    [SerializeField] private PlatformEndDetector _platformEndDetector;
    [SerializeField] private ObstacleDetector _targetDetector;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    public bool IsNeedChangeDirection => ObstacleDetected || PlatformEndDetected;
    public bool IsTargetInRadius => _targetDetector.IsDetected;
    private bool ObstacleDetected => _obstacleDetector.IsDetected;
    private bool PlatformEndDetected => _platformEndDetector.IsDetected;

    public void Initialize()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = transform.right;
    }

    public void Move()
    {
        Vector2 velocity = _speed * _direction;

        _rigidbody2D.velocity = velocity;
    }

    public void StopMove()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void ChangeDirection()
    {
        Vector2 scale = new Vector2(-transform.localScale.x, transform.localScale.y);

        transform.localScale = scale;
        _direction = -_direction;
    }
}
