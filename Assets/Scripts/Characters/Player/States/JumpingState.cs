namespace PlayerState
{
    public class JumpingState : AirbornState
    {
        private readonly PlayerView _view;

        public JumpingState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents) : base(stateSwitcher, playerComponents)
        {
            _view = playerComponents.View;
        }

        public override void Enter()
        {
            base.Enter();

            Mover.Jump();
            _view.StartJump();
        }

        public override void Update()
        {
            base.Update();

            if (Mover.VerticalVelocity <= 0)
            {
                StateSwitcher.SwitchState<FallingState>();
            }
        }
    }
}