namespace PlayerState
{
    public class FallingState : AirbornState
    {
        private readonly ObstacleDetector _groundDetector;
        private readonly PlayerView _view;

        public FallingState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents) : base(stateSwitcher, playerComponents)
        {
            _view = playerComponents.View;
            _groundDetector = playerComponents.GroundDetector;
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