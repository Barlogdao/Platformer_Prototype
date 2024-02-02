using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private EnemyView _view;
    [SerializeField] private ObstacleDetector _obstacleDetector;
    [SerializeField] private PlatformEndDetector _platformEndDetector;

    private EnemyStateMachine _stateMachine;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    public bool ObstacleDetected => _obstacleDetector.IsDetected;
    public bool PlatformEndDetected => _platformEndDetector.IsDetected;
    public EnemyView View => _view;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _view.Initialize();
        _direction = transform.right;

        _stateMachine = new EnemyStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
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
