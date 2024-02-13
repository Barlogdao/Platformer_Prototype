namespace EnemyStates
{
    public class AttackState : EnemyBaseState
    {
        private readonly EnemyAnimatorEvents _animatorEvents;
        private readonly Attacker _attacker;

        public AttackState(IStateSwitcher stateSwitcher, Enemy.Components components) : base(stateSwitcher, components)
        {
            _animatorEvents = components.AnimatorEvents;
            _attacker = components.Attacker;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartAttack();
            _animatorEvents.AttackHits += OnAttackHits;
            _animatorEvents.AttackEnded += OnAttackEnded;
        }

        public override void Exit()
        {
            base.Exit();

            _animatorEvents.AttackHits -= OnAttackHits;
            _animatorEvents.AttackEnded -= OnAttackEnded;
        }

        private void OnAttackHits()
        {
            _attacker.Hit();
        }

        private void OnAttackEnded()
        {
            StateSwitcher.SwitchState<WaitingState>();
        }
    }
}