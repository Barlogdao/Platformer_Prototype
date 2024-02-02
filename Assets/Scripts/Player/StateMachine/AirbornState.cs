namespace PlayerState
{
    public class AirbornState : MovementState
    {
        public AirbornState(IStateSwitcher stateSwitcher, Player player) : base(stateSwitcher, player) { }
    }
}