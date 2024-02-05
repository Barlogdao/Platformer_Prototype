using Controls.Input;

public class PlayerComponents
{
    public PlayerComponents(PlayerView view, PlayerMover mover, GameInput input, ObstacleDetector groundDetector)
    {
        View = view;
        Mover = mover;
        Input = input;
        GroundDetector = groundDetector;
    }

    public PlayerView View { get; }
    public PlayerMover Mover { get; }
    public GameInput Input { get; }
    public ObstacleDetector GroundDetector { get; }
}