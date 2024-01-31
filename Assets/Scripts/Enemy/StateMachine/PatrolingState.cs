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

        public void Enter()
        {
           _view.StartRun();
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            _enemy.Move();

            if (_enemy.ObstacleDetected || _enemy.PlatformEndDetected)
            {
                _stateSwitcher.SwitchState<WaitingState>();
            }
        }
    }
}