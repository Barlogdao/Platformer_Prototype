using UnityEngine.InputSystem;

namespace PlayerState
{
    public abstract class MovementState : PlayerBaseState
    {
        protected readonly PlayerMover Mover;

        protected MovementState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
            Mover = components.Mover;
        }

        public override void Enter()
        {
            base.Enter();

            Input.Player.Attack.performed += OnAttackPressed;
        }

        public override void Exit()
        {
            base.Exit();

            Input.Player.Attack.performed -= OnAttackPressed;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            Mover.Move(HorizontalInput);
        }

        private void OnAttackPressed(InputAction.CallbackContext context)
        {
            if (IsGrounded == true)
            {
                StateSwitcher.SwitchState<AttackState>();
            }
            else
            {
                StateSwitcher.SwitchState<AirAttackState>();
            }
        }
    }
}