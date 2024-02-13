using EnemyStates;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyView _view;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private EnemyAnimatorEvents _animatorEvents;
    [SerializeField] private TargetDetector _targetDetector;

    private StateMachine _stateMachine;
    private Health _health;

    public event Action Hitted;

    public bool IsAlive => _health.IsPositive;

    public void Initialize(EnemyConfig config)
    {
        _health = new Health(config.Health);
        _view.Initialize(this);
        _mover.Initialize(config.Speed);
        _attacker.Initialize(config.Damage, config.PushForce);

        StateMachineInit(config.StateMachineConfig);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    private void StateMachineInit(EnemyStateMachineConfig config)
    {
        _stateMachine = new StateMachine();

        Components components = new Components(_mover, _view, _attacker, _animatorEvents, this, _targetDetector);

        _stateMachine.AddState(new WaitingState(_stateMachine, components, config.WaitDuration));
        _stateMachine.AddState(new PatrolingState(_stateMachine, components));
        _stateMachine.AddState(new AttackState(_stateMachine, components));
        _stateMachine.AddState(new DeadState(_stateMachine, components));
        _stateMachine.AddState(new ChasingState(_stateMachine, components, config.ChaseDistance));

        _stateMachine.SwitchState<WaitingState>();
    }

    public void TakeDamage(int damage)
    {
        _health.Subtract(damage);
        Hitted?.Invoke();
    }

    public class Components
    {
        public Components(EnemyMover mover, EnemyView view, Attacker attacker, EnemyAnimatorEvents animatorEvents, IDamagable damagable, TargetDetector targetDetector)
        {
            Mover = mover;
            View = view;
            Attacker = attacker;
            AnimatorEvents = animatorEvents;
            Damagable = damagable;
            TargetDetector = targetDetector;
        }

        public EnemyMover Mover { get; }
        public EnemyView View { get; }
        public Attacker Attacker { get; }
        public EnemyAnimatorEvents AnimatorEvents { get; }
        public IDamagable Damagable { get; }
        public TargetDetector TargetDetector { get; }
    }
}