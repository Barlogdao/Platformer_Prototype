namespace PlayerState
{
    public class ReturnState : BaseState
    {
        public ReturnState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents) : base(stateSwitcher, playerComponents) { }

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