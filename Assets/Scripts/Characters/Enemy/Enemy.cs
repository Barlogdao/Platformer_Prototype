using EnemyStates;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyView _view;
    [SerializeField] private EnemyMover _mover;

    private StateMachine _stateMachine;

    private void Awake()
    {
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

    private void StateMachineInit()
    {
        _stateMachine = new StateMachine();

        _stateMachine.AddState(new WaitingState(_view, _stateMachine));
        _stateMachine.AddState(new PatrolingState(_view, _mover, _stateMachine));

        _stateMachine.SwitchState<WaitingState>();
    }
}
