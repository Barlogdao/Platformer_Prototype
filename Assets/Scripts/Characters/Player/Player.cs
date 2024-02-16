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
        _mover.Initialize(config.Speed,config.JumpForce);
        _health.Initialize(config.Health);
        _attacker.Initialize(config.Damage, config.PushForce);

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
        _input.Player.Interact.performed -= OnInteractPressed;
        _picker.Picked -= OnPick;
        _input.Disable();
    }

    private void StateMachineInit()
    {
        Components components = new Components(_view, _mover, _input, _groundDetector, _animatorEvents, _health, _attacker);
        _stateMachine = new StateMachine();

        _stateMachine.AddState(new IdlingState(_stateMachine, components));
        _stateMachine.AddState(new RunningState(_stateMachine, components));
        _stateMachine.AddState(new JumpingState(_stateMachine, components));
        _stateMachine.AddState(new FallingState(_stateMachine, components));
        _stateMachine.AddState(new AttackState(_stateMachine, components));
        _stateMachine.AddState(new AirAttackState(_stateMachine, components));
        _stateMachine.AddState(new HitState(_stateMachine, components));
        _stateMachine.AddState(new ReturnState(_stateMachine, components));
        _stateMachine.AddState(new DeadState(_view, _mover));

        _stateMachine.SwitchState<IdlingState>();
    }

    private void OnPick(IPickable pickable)
    {
        if (pickable is Coin coin)
        {
            _wallet.AddMoney(coin.Value);
        }
        else if (pickable is HealthKit healthKit)
        {
            _health.Heal(healthKit.Value);
        }
    }

    private void OnInteractPressed(InputAction.CallbackContext context)
    {
        Interacted?.Invoke();
    }

    public class Components
    {
        public Components(PlayerView view, PlayerMover mover, GameInput input, ObstacleDetector groundDetector, PlayerAnimatorEvents animatorEvents, IDamagable damagable, Attacker attacker)
        {
            View = view;
            Mover = mover;
            Input = input;
            GroundDetector = groundDetector;
            AnimatorEvents = animatorEvents;
            Damagable = damagable;
            Attacker = attacker;
        }

        public PlayerView View { get; }
        public PlayerMover Mover { get; }
        public GameInput Input { get; }
        public ObstacleDetector GroundDetector { get; }
        public PlayerAnimatorEvents AnimatorEvents { get; }
        public Attacker Attacker { get; }

        public IDamagable Damagable { get; }
    }
}