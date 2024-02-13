namespace PlayerState
{
    public class FallingState : AirbornState
    {
        private readonly ObstacleDetector _groundDetector;
        private readonly PlayerView _view;

        public FallingState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
            _view = components.View;
            _groundDetector = components.GroundDetector;
        }

        public override void Enter()
        {
            base.Enter();

            _view.StartFall();
        }

        public override void Update()
        {
            base.Update();

            if (_groundDetector.IsDetected)
            {
                if (IsHorizontInputZero == true)
                    StateSwitcher.SwitchState<IdlingState>();
                else
                    StateSwitcher.SwitchState<RunningState>();
            }
        }
    }
}