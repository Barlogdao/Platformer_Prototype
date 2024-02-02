using Controls.Input;
using UnityEngine.InputSystem;

namespace PlayerState
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly PlayerView View;
        protected readonly PlayerMover Mover;
        protected readonly GameInput Input;
        protected readonly Player Player;

        protected MovementState(IStateSwitcher stateSwitcher, Player player)
        {
            StateSwitcher = stateSwitcher;
            Player = player;
            View = Player.View;
            Mover = Player.Mover;
            Input = Player.Input;
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