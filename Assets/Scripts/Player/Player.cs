using Controls.Input;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerView _view;
    [SerializeField] ObstacleDetector _groundDetector;

    private GameInput _input;
    private PlayerStateMachine _stateMachine;

    public ObstacleDetector GroundDetector => _groundDetector;
    public PlayerMover Mover => _mover;
    public PlayerView View => _view;
    public GameInput Input => _input;

    private void Awake()
    {
        _input = new GameInput();
        _view.Initialize();
        _mover.Initialize();

        _stateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
