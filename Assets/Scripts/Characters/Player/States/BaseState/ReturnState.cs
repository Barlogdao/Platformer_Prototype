namespace PlayerState
{
    public class ReturnState : PlayerBaseState
    {
        public ReturnState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
        }

        public override void Enter()
        {
            base.Enter();

            if (IsGrounded == false)
            {
                StateSwitcher.SwitchState<FallingState>();
            }
            else if (IsHorizontInputZero == false)
            {
                StateSwitcher.SwitchState<RunningState>();
            }
            else
            {
                StateSwitcher.SwitchState<IdlingState>();
            }
        }
    }
}