using Controls.Input;
using PlayerState;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IInteractor
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerView _view;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private PlayerAnimatorEvents _animatorEvents;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private ObstacleDetector _groundDetector;
    [SerializeField] private PlayerPicker _picker;

    private GameInput _input;
    private StateMachine _stateMachine;
    private Wallet _wallet;

    public event Action Interacted;

    public void Initialize(PlayerConfig config)
    {
        _input = new GameInput();
        _wallet = new Wallet(config.StartMoney);

        _view.Initialize();
        _mover.Initialize();
        _health.Initialize(config.Health);
        _attacker.Initialize(config.Damage);
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

    private void StateMachineInit()
    {
        PlayerComponents playerComponents = new PlayerComponents(_view, _mover, _input, _groundDetector,_animatorEvents, _health);
        _stateMachine = new StateMachine();

        _stateMachine.AddState(new IdlingState(_stateMachine, playerComponents));
        _stateMachine.AddState(new RunningState(_stateMachine, playerComponents));
        _stateMachine.AddState(new JumpingState(_stateMachine, playerComponents));
        _stateMachine.AddState(new FallingState(_stateMachine, playerComponents));
        _stateMachine.AddState(new AttackState(_stateMachine, playerComponents));
        _stateMachine.AddState(new HitState(_stateMachine, playerComponents));
        _stateMachine.AddState(new ReturnState(_stateMachine, playerComponents));
        _stateMachine.AddState(new DeadState(_view, _mover));

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
