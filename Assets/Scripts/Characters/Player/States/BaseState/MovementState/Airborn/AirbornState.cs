namespace PlayerState
{
    public abstract class AirbornState : MovementState
    {
        protected AirbornState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
        }
    }
}