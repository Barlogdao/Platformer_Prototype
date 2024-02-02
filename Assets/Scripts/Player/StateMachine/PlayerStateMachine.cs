using PlayerState;
using System;
using System.Collections.Generic;

public class PlayerStateMachine : IStateSwitcher
{
    private readonly Dictionary<Type, IState> _states;

    private IState _currentState;

    public PlayerStateMachine(Player player)
    {
        _states = new Dictionary<Type, IState>();

        _states[typeof(IdlingState)] = new IdlingState(this, player);
        _states[typeof(RunningState)] = new RunningState(this, player);
        _states[typeof(JumpingState)] = new JumpingState(this, player);
        _states[typeof(FallingState)] = new FallingState(this, player);

        _currentState = _states[typeof(IdlingState)];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states[typeof(T)];

        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
    public void FixedUpdate() => _currentState.FixedUpdate();
}
