namespace PlayerState
{
    public class RunningState : GroundedState
    {
        public RunningState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
        }

        public override void Enter()
        {
            base.Enter();

            View.StartRun();
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