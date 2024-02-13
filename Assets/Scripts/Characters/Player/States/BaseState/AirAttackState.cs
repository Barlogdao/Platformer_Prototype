namespace PlayerState
{
    public class AirAttackState : PlayerBaseState
    {
        private readonly PlayerAnimatorEvents _animatorEvents;
        private readonly Attacker _attacker;

        public AirAttackState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
            _animatorEvents = components.AnimatorEvents;
            _attacker = components.Attacker;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartAirAttack();
            _animatorEvents.AttackHits += OnAttackHits;
            _animatorEvents.AttackEnded += OnAttackEnds;
        }

        public override void Exit()
        {
            base.Exit();

            _animatorEvents.AttackHits -= OnAttackHits;
            _animatorEvents.AttackEnded -= OnAttackEnds;
        }

        private void OnAttackEnds()
        {
            StateSwitcher.SwitchState<ReturnState>();
        }


        private void OnAttackHits()
        {
            _attacker.Hit();
        }
    }
}