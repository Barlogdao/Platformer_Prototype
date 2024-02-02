namespace PlayerState
{
    public class JumpingState : AirbornState
    {
        public JumpingState(IStateSwitcher stateSwitcher, Player player) : base(stateSwitcher, player) { }
 
        public override void Enter()
        {
            base.Enter();

            Mover.Jump();
            View.StartJump();
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