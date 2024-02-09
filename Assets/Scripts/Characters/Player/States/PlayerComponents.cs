using Controls.Input;

public class PlayerComponents
{
    public PlayerComponents(PlayerView view, PlayerMover mover, GameInput input, ObstacleDetector groundDetector, PlayerAnimatorEvents animatorEvents, IDamagable damagable)
    {
        View = view;
        Mover = mover;
        Input = input;
        GroundDetector = groundDetector;
        AnimatorEvents = animatorEvents;
        Damagable = damagable;
    }

    public PlayerView View { get; }
    public PlayerMover Mover { get; }
    public GameInput Input { get; }
    public ObstacleDetector GroundDetector { get; }
    public PlayerAnimatorEvents AnimatorEvents { get;}

    public IDamagable Damagable { get; }
}