using UnityEngine.InputSystem;

namespace PlayerState
{
    public class JumpingState : AirbornState
    {
        private readonly PlayerView _view;
        private bool _isDoubleJumpUsed;

        public JumpingState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
            _view = components.View;
            
        }

        public override void Enter()
        {
            base.Enter();

            _isDoubleJumpUsed = false;
            Input.Player.Jump.performed += OnJumpPressed;

            Mover.Jump();
            _view.StartJump();
        }

        public override void Exit()
        {
            base.Exit();

            Input.Player.Jump.performed -= OnJumpPressed;

        }

        public override void Update()
        {
            base.Update();

            if (Mover.VerticalVelocity <= 0)
            {
                StateSwitcher.SwitchState<FallingState>();
            }
        }

        private void OnJumpPressed(InputAction.CallbackContext context)
        {
            if(_isDoubleJumpUsed == false)
            {
                Mover.Jump();
                _isDoubleJumpUsed = true;
            }
        }
    }
}