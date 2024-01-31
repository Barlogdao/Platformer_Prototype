using UnityEngine.InputSystem;

namespace PlayerState
{
    public class GroundedState : MovementState
    {
        private ObstacleDetector _groundDetector;
        public GroundedState(IStateSwitcher stateSwitcher, Player player) : base(stateSwitcher, player)
        {
            _groundDetector = Player.GroundDetector;
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

            if (_groundDetector.IsDetected == false)
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