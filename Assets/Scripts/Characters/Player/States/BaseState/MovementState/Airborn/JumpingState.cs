namespace PlayerState
{
    public class JumpingState : AirbornState
    {
        private readonly PlayerView _view;

        public JumpingState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
            _view = components.View;
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