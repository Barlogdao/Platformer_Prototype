using UnityEngine;

namespace EnemyStates
{
    public class WaitingState : EnemyBaseState
    {
        private readonly float _waitDuration;

        private float _elapsedTime;

        public WaitingState(IStateSwitcher stateSwitcher, Enemy.Components components, float waitDuration) : base(stateSwitcher, components)
        {
            _waitDuration = waitDuration;
        }

        public override void Enter()
        {
            base.Enter();

            _elapsedTime = 0f;
            View.StartIdle();
            Mover.StopMove();
        }

        public override void Update()
        {
            base.Update();

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _waitDuration)
            {
                ChangeState();
            }

        }

        private void ChangeState()
        {
            if (Attacker.HasTargetInArea == true)
            {
                StateSwitcher.SwitchState<AttackState>();
            }
            else if (TargetDetector.IsDetected())
            {
                StateSwitcher.SwitchState<ChasingState>();
            }
            else
            {
                StateSwitcher.SwitchState<PatrolingState>();
            }
        }
    }
}