using System;
using System.Collections.Generic;
using EnemyStates;

public class EnemyStateMachine : IStateSwitcher
{
    private readonly Dictionary<Type, IState> _states;

    private IState _currentState;

    public EnemyStateMachine(Enemy enemy)
    {
        _states = new Dictionary<Type, IState>();

        _states[typeof(WaitingState)] = new WaitingState(enemy, this);
        _states[typeof(PatrolingState)] = new PatrolingState(enemy, this);

        _currentState = _states[typeof(WaitingState)];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states[typeof(T)];

        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void FixedUpdate()
    {
        _currentState.FixedUpdate();
    }
}
