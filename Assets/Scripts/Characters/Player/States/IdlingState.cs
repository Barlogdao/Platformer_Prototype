namespace PlayerState
{
    public class IdlingState : GroundedState
    {
        private readonly PlayerView _view;

        public IdlingState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents) : base(stateSwitcher, playerComponents)
        {
            _view = playerComponents.View;
        }

        public override void Enter()
        {
            base.Enter();

            _view.StartIdle();
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontInputZero == false)
            {
                StateSwitcher.SwitchState<RunningState>();
            }
        }
    }
}