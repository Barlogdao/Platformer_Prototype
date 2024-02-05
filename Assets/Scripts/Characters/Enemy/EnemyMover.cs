using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ObstacleDetector _obstacleDetector;
    [SerializeField] private PlatformEndDetector _platformEndDetector;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    public bool IsNeedChangeDirection => ObstacleDetected || PlatformEndDetected;
    private bool ObstacleDetected => _obstacleDetector.IsDetected;
    private bool PlatformEndDetected => _platformEndDetector.IsDetected;

    public void Initialize()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = transform.right;
    }

    public void Move()
    {
        Vector3 translation = _direction * _speed * Time.deltaTime;

        _rigidbody2D.MovePosition(transform.position + translation);
    }

    public void ChangeDirection()
    {
        Vector2 scale = new Vector2(-transform.localScale.x, transform.localScale.y);

        transform.localScale = scale;
        _direction = -_direction;
    }
}
