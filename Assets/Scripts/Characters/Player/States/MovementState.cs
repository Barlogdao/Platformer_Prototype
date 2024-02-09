namespace PlayerState
{
    public abstract class MovementState : BaseState
    {
        protected readonly PlayerMover Mover;

        protected MovementState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents):base(stateSwitcher, playerComponents)    
        {
            Mover = playerComponents.Mover;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            Mover.Move(HorizontalInput);
        }
    }
}