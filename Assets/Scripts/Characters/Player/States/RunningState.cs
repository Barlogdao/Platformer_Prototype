namespace PlayerState
{
    public class RunningState : GroundedState
    {
        private readonly PlayerView _view;

        public RunningState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents) : base(stateSwitcher, playerComponents)
        {
            _view = playerComponents.View;
        }

        public override void Enter()
        {
            base.Enter();

            _view.StartRun();
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontInputZero == true)
            {
                StateSwitcher.SwitchState<IdlingState>();
            }
        }
    }
}