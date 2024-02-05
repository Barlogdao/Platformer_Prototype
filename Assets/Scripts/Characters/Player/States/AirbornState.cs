namespace PlayerState
{
    public class AirbornState : MovementState
    {
        public AirbornState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents) : base(stateSwitcher, playerComponents)
        {
        }
    }
}