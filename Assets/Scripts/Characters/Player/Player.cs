using Controls.Input;
using PlayerState;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IInteractor, IDamagable
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerView _view;
    [SerializeField] private ObstacleDetector _groundDetector;
    [SerializeField] private PlayerPicker _picker;

    private GameInput _input;
    private StateMachine _stateMachine;
    private Wallet _wallet;
    private Health _health;

    public bool IsAlive => _health.IsPositive;

    public event Action Interacted;

    public void Initialize(PlayerConfig config)
    {
        _input = new GameInput();
        _wallet = new Wallet(config.StartMoney);
        _health = new Health(config.Health);

        _view.Initialize();
        _mover.Initialize();
        StateMachineInit();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Interact.performed += OnInteractPressed;
        _picker.Picked += OnPick;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Interact.performed -= OnInteractPressed;
        _picker.Picked -= OnPick;
    }

    public void TakeDamage(int damage)
    {
        _health.Subtract(damage);
    }

    private void StateMachineInit()
    {
        PlayerComponents playerComponents = new PlayerComponents(_view, _mover, _input, _groundDetector);
        _stateMachine = new StateMachine();

        _stateMachine.AddState(new IdlingState(_stateMachine, playerComponents));
        _stateMachine.AddState(new RunningState(_stateMachine, playerComponents));
        _stateMachine.AddState(new JumpingState(_stateMachine, playerComponents));
        _stateMachine.AddState(new FallingState(_stateMachine, playerComponents));

        _stateMachine.SwitchState<IdlingState>();
    }

    private void OnPick(IPickable pickable)
    {
        if (pickable is Coin coin)
        {
            _wallet.AddMoney(coin.Value);
        }
    }

    private void OnInteractPressed(InputAction.CallbackContext context)
    {
        Interacted?.Invoke();
    }
}
