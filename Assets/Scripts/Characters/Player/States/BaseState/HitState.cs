namespace PlayerState
{
    public class HitState : PlayerBaseState
    {
        private readonly PlayerAnimatorEvents _animatorEvents;
        private readonly PlayerMover _mover;

        public HitState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
            _animatorEvents = components.AnimatorEvents;
            _mover = components.Mover;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartHit();
            _mover.StopMove();
            _animatorEvents.HitEnded += OnHitEnded;
        }

        public override void Exit()
        {
            base.Exit();

            _animatorEvents.HitEnded -= OnHitEnded;
        }

        private void OnHitEnded()
        {
            StateSwitcher.SwitchState<ReturnState>();
        }
    }
}