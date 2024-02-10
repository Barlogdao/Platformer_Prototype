using UnityEngine;

namespace EnemyStates
{
    public class WaitingState : EnemyBaseState
    {
        private readonly EnemyView _view;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly float _waitDuration;

        private float _elapsedTime;

        public WaitingState(IStateSwitcher stateSwitcher, EnemyView view, EnemyMover mover, Attacker attacker, IDamagable damagable) : base(stateSwitcher, view, mover, attacker, damagable)
        {
            _view = view;
            _stateSwitcher = stateSwitcher;
            _waitDuration = 1f;
        }

        public override void Enter()
        {
            base.Enter();

            _elapsedTime = 0f;
            _view.StartIdle();
            Mover.StopMove();
        }

        public override void Update()
        {
            base.Update(); 

            _elapsedTime += Time.deltaTime;
            
            if (_elapsedTime >= _waitDuration) 
            {
                _stateSwitcher.SwitchState<PatrolingState>();
            }
        }
    }
}