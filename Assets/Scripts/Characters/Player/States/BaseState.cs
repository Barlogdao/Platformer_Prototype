using Controls.Input;

namespace PlayerState
{
    public class BaseState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly GameInput Input;
        protected readonly PlayerView View;
        protected readonly IDamagable Damagable;

        private readonly ObstacleDetector _groundDetector;
        protected BaseState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents)
        {
            StateSwitcher = stateSwitcher;
            Input = playerComponents.Input;
            View = playerComponents.View;
            Damagable = playerComponents.Damagable;
            _groundDetector = playerComponents.GroundDetector;
        }

        protected float HorizontalInput { get; private set; }
        protected bool IsHorizontInputZero => HorizontalInput == 0;
        protected bool IsGrounded => _groundDetector.IsDetected;

        public virtual void Enter() 
        {
            Damagable.Hitted += OnHitted;
        }

        public virtual void Exit() 
        {
            Damagable.Hitted -= OnHitted;
        }

        public virtual void FixedUpdate() { }

        public virtual void Update()
        {
            if (Damagable.IsAlive == false)
            {
                StateSwitcher.SwitchState<DeadState>();
                return;
            }

            HorizontalInput = Input.Player.Move.ReadValue<float>();
        }
        private void OnHitted()
        {
            StateSwitcher.SwitchState<HitState>();
        }
    }
}