using System;
using System.Collections.Generic;

public class StateMachine : IStateSwitcher
{
    private readonly Dictionary<Type, IState> _states;

    private IState _currentState;

    public StateMachine()
    {
        _states = new Dictionary<Type, IState>();
    }

    public void AddState (IState state)
    {
        if (_states.ContainsKey(state.GetType()))
        {
            throw new Exception($"State {state.GetType()} is already exists");
        }

        _states[state.GetType()] = state;
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states[typeof(T)] ?? throw new Exception($"State {typeof(T)} is not exists");

        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }
    public void Update() => _currentState.Update();
    public void FixedUpdate() => _currentState.FixedUpdate();
}
