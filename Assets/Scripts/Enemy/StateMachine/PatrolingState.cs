namespace EnemyStates
{
    public class PatrolingState : IState
    {
        private readonly Enemy _enemy;
        private readonly EnemyView _view;
        private readonly IStateSwitcher _stateSwitcher;
        
        public PatrolingState(Enemy enemy, IStateSwitcher stateSwitcher)
        {
            _enemy = enemy;
            _view = _enemy.View;
            _stateSwitcher = stateSwitcher;
        }

        private bool IsNeedChangeDirection => _enemy.ObstacleDetected || _enemy.PlatformEndDetected;

        public void Enter()
        {
            TryChangeDirection();
           _view.StartRun();
        }

        public void Exit() { }   

        public void Update()
        {
            if (IsNeedChangeDirection == true)
            {
                _stateSwitcher.SwitchState<WaitingState>();
            }
        }
        public void FixedUpdate()
        {
            _enemy.Move();
        }

        private void TryChangeDirection()
        {
            if (IsNeedChangeDirection == true)
            {
                _enemy.ChangeDirection();
            }
        }
    }
}