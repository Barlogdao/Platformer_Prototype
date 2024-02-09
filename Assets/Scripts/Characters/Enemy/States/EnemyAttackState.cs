namespace EnemyStates
{
    public class EnemyAttackState : IState
    {
        private readonly EnemyView _view;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly EnemyAnimatorEvents _animatorEvents;

        public EnemyAttackState(EnemyView view, IStateSwitcher stateSwitcher, EnemyAnimatorEvents animatorEvents)
        {
            _view = view;
            _stateSwitcher = stateSwitcher;
            _animatorEvents = animatorEvents;
        }

        public void Enter()
        {
            _view.StartAttack();
            _animatorEvents.AttackEnded += OnAttackEnded;
        }

        private void OnAttackEnded()
        {
            _stateSwitcher.SwitchState<WaitingState>();
        }

        public void Exit()
        {
            _animatorEvents.AttackEnded -= OnAttackEnded;
        }

        public void FixedUpdate() { }

        public void Update() { }
    }
}