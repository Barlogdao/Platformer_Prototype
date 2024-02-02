using UnityEngine;

namespace EnemyStates
{
    public class WaitingState : IState
    {
        private readonly Enemy _enemy;
        private readonly EnemyView _view;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly float _waitDuration;

        private float _elapsedTime;

        public WaitingState(Enemy enemy, IStateSwitcher stateSwitcher)
        {
            _enemy = enemy;
            _view = _enemy.View;
            _stateSwitcher = stateSwitcher;
            _waitDuration = 1f;
        }

        public void Enter()
        {
            _view.StartIdle();
            _elapsedTime = 0f;
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            _elapsedTime += Time.deltaTime;
            
            if (_elapsedTime >= _waitDuration) 
            {
                _stateSwitcher.SwitchState<PatrolingState>();
            }
        }
        public void FixedUpdate()
        {

        }
    }
}