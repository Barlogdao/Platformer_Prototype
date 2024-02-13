namespace PlayerState
{
    public class IdlingState : GroundedState
    {
        public IdlingState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
        }

        public override void Enter()
        {
            base.Enter();

            View.StartIdle();
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