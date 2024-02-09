namespace PlayerState
{
    public class HitState : BaseState
    {
        private readonly PlayerAnimatorEvents _animatorEvents;
        public HitState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents) : base(stateSwitcher, playerComponents)
        {
            _animatorEvents = playerComponents.AnimatorEvents;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartHit();
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