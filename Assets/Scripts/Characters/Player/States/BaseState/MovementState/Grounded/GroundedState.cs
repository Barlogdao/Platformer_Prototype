using UnityEngine.InputSystem;

namespace PlayerState
{
    public abstract class GroundedState : MovementState
    {
        protected GroundedState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Input.Player.Jump.performed += OnJumpPressed;
        }

        public override void Exit()
        {
            base.Exit();
            Input.Player.Jump.performed -= OnJumpPressed;
        }

        public override void Update()
        {
            base.Update();

            if (IsGrounded == false)
            {
                StateSwitcher.SwitchState<FallingState>();
            }
        }

        private void OnJumpPressed(InputAction.CallbackContext context)
        {
            StateSwitcher.SwitchState<JumpingState>();
        }
    }
}