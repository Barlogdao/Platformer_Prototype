using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private EnemyView _view;
    [SerializeField] private ObstacleDetector _obstacleDetector;
    [SerializeField] private PlatformEndDetector _platformEndDetector;

    private EnemyStateMachine _stateMachine;
    private Vector2 _direction;

    public bool ObstacleDetected => _obstacleDetector.IsDetected;
    public bool PlatformEndDetected => _platformEndDetector.IsDetected;
    public EnemyView View => _view;

    private void Awake()
    {
        _view.Initialize();
        _direction = transform.right;

        _stateMachine = new EnemyStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void Move()
    {
        Vector2 translation = _direction * _speed * Time.deltaTime;

        transform.Translate(translation);
    }

    public void ChangeDirection()
    {
        Vector2 changedScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        transform.localScale = changedScale;
        _direction = -_direction;
    }
}
