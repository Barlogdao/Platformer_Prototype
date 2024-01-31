namespace PlayerState
{
    public class FallingState : AirbornState
    {
        private ObstacleDetector _groundDetector;
        public FallingState(IStateSwitcher stateSwitcher, Player player) : base(stateSwitcher, player)
        {
            _groundDetector = Player.GroundDetector;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartFall();
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