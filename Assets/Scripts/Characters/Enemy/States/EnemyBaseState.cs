using EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyView View;
    protected EnemyMover Mover;
    protected Attacker Attacker;
    protected IStateSwitcher StateSwitcher;
    protected IDamagable Damagable;

    protected EnemyBaseState(IStateSwitcher stateSwitcher, EnemyView view, EnemyMover mover, Attacker attacker, IDamagable damagable)
    {
        View = view;
        Mover = mover;
        Attacker = attacker;
        StateSwitcher = stateSwitcher;
        Damagable = damagable;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void Update()
    {
        if(Damagable.IsAlive == false)
        {
            StateSwitcher.SwitchState<EnemyDeadState>();
        }
    }
}
