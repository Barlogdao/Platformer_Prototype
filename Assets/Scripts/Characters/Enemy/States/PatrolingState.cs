namespace EnemyStates
{
    public class PatrolingState : EnemyBaseState
    {
        private readonly EnemyView _view;
        private readonly EnemyMover _mover;
        private readonly IStateSwitcher _stateSwitcher;
        
        public PatrolingState(IStateSwitcher stateSwitcher, EnemyView view, EnemyMover mover, Attacker attacker, IDamagable damagable):base (stateSwitcher,view,mover,attacker,damagable)
        {
            _view = view;
            _mover = mover;
            _stateSwitcher = stateSwitcher;
        }

        public override void Enter()
        {
            base.Enter ();
            TryChangeDirection();
           _view.StartRun();
        }


        public override void Update()
        {
            base .Update ();

            if (_mover.IsNeedChangeDirection == true)
            {
                _stateSwitcher.SwitchState<WaitingState>();
            }
            else if(_mover.IsTargetInRadius == true)
            {
                _stateSwitcher.SwitchState<EnemyAttackState>();
            }

        }

        public override void FixedUpdate()
        {
            base .FixedUpdate ();
            _mover.Move();
        }

        private void TryChangeDirection()
        {

            if (_mover.IsNeedChangeDirection == true)
            {
                _mover.ChangeDirection();
            }
        }
    }
}