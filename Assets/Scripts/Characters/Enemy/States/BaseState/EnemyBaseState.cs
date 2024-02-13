using EnemyStates;

public abstract class EnemyBaseState : IState
{
    protected EnemyView View;
    protected EnemyMover Mover;
    protected Attacker Attacker;
    protected IStateSwitcher StateSwitcher;
    protected IDamagable Damagable;
    protected TargetDetector TargetDetector;

    protected EnemyBaseState(IStateSwitcher stateSwitcher, Enemy.Components components)
    {
        View = components.View;
        Mover = components.Mover;
        Attacker = components.Attacker;
        StateSwitcher = stateSwitcher;
        Damagable = components.Damagable;
        TargetDetector = components.TargetDetector;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void FixedUpdate() { }

    public virtual void Update()
    {
        if (Damagable.IsAlive == false)
        {
            StateSwitcher.SwitchState<DeadState>();

            return;
        }
    }
}