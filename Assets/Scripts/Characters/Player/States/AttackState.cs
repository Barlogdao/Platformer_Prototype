namespace PlayerState
{
    public class AttackState : BaseState
    {
        private readonly PlayerAnimatorEvents _animatorEvents;
        private readonly PlayerMover _mover;

        public AttackState(IStateSwitcher stateSwitcher, PlayerComponents playerComponents):base(stateSwitcher, playerComponents)
        {
            _animatorEvents = playerComponents.AnimatorEvents;
            _mover = playerComponents.Mover;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartAttack();
            _mover.StopMove();
            _animatorEvents.AttackEnded += OnAttackEnds;
        }

        public override void Exit()
        {
            base.Exit();

            _animatorEvents.AttackEnded += OnAttackEnds;
        }

        private void OnAttackEnds()
        {
            StateSwitcher.SwitchState<ReturnState>();
        }
    }
}