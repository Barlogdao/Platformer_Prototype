using Controls.Input;

namespace PlayerState
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly PlayerMover Mover;
        protected readonly GameInput Input;

        protected MovementState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents)
        {
            StateSwitcher = stateSwitcher;
            Mover = playerComponents.Mover;
            Input = playerComponents.Input;
        }

        protected float HorizontalInput { get; private set; }
        protected bool IsHorizontInputZero => HorizontalInput == 0;

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update()
        {
            HorizontalInput = Input.Player.Move.ReadValue<float>();
        }

        public virtual void FixedUpdate()
        {
            Mover.Move(HorizontalInput);
        }
    }
}