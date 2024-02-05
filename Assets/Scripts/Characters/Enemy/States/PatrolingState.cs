namespace EnemyStates
{
    public class PatrolingState : IState
    {
        private readonly EnemyView _view;
        private readonly EnemyMover _mover;
        private readonly IStateSwitcher _stateSwitcher;
        
        public PatrolingState(EnemyView view, EnemyMover mover, IStateSwitcher stateSwitcher)
        {
            _view = view;
            _mover = mover;
            _stateSwitcher = stateSwitcher;
        }

        public void Enter()
        {
            TryChangeDirection();
           _view.StartRun();
        }

        public void Exit() { }   

        public void Update()
        {
            if (_mover.IsNeedChangeDirection == true)
            {
                _stateSwitcher.SwitchState<WaitingState>();
            }
        }

        public void FixedUpdate()
        {
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