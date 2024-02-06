using UnityEngine;

namespace EnemyStates
{
    public class WaitingState : IState
    {
        private readonly EnemyView _view;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly float _waitDuration;

        private float _elapsedTime;

        public WaitingState(EnemyView view, IStateSwitcher stateSwitcher)
        {
            _view = view;
            _stateSwitcher = stateSwitcher;
            _waitDuration = 1f;
        }

        public void Enter()
        {
            _elapsedTime = 0f;
            _view.StartIdle();
        }

        public void Exit() { }

        public void Update()
        {
            _elapsedTime += Time.deltaTime;
            
            if (_elapsedTime >= _waitDuration) 
            {
                _stateSwitcher.SwitchState<PatrolingState>();
            }
        }
        public void FixedUpdate() { }
    }
}