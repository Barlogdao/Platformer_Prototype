using UnityEngine.InputSystem;

namespace PlayerState
{
    public class GroundedState : MovementState
    {
        public GroundedState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents) : base(stateSwitcher, playerComponents) { }

        public override void Enter()
        {
            base.Enter();

            Input.Player.Jump.performed += OnJumpPressed;
            Input.Player.Attack.performed += OnAttackPressed;
        }

        public override void Exit()
        {
            base.Exit();
            Input.Player.Jump.performed -= OnJumpPressed;
            Input.Player.Attack.performed -= OnAttackPressed;
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

        private void OnAttackPressed(InputAction.CallbackContext context)
        {
            StateSwitcher.SwitchState<AttackState>();
        }
    }
}