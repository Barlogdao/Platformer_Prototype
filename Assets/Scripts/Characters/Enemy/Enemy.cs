using EnemyStates;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyView _view;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private EnemyAnimatorEvents _animatorEvents;

    private StateMachine _stateMachine;
    private Health _health;

    public event Action Hitted;

    public bool IsAlive => _health.IsPositive;

    private void Awake()
    {
        _health = new Health(8);

        _view.Initialize();
        _mover.Initialize();
        _attacker.Initialize(4);
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

    private void StateMachineInit()
    {
        _stateMachine = new StateMachine();

        _stateMachine.AddState(new WaitingState(_stateMachine, _view, _mover, _attacker, this));
        _stateMachine.AddState(new PatrolingState(_stateMachine, _view, _mover, _attacker, this));
        _stateMachine.AddState(new EnemyAttackState(_view, _stateMachine, _animatorEvents));
        _stateMachine.AddState(new EnemyDeadState(_view));

        _stateMachine.SwitchState<WaitingState>();
    }

    public void TakeDamage(int damage)
    {
        _health.Subtract(damage);
    }
}
