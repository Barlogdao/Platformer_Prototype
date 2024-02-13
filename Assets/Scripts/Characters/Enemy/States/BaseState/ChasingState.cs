using UnityEngine;

namespace EnemyStates
{
    public class ChasingState : EnemyBaseState
    {
        private readonly Transform _transform;
        private readonly float _chaseDistance;

        private Transform _target = null;

        public ChasingState(IStateSwitcher stateSwitcher, Enemy.Components components, float chaseDistance) : base(stateSwitcher, components)
        {
            _transform = Mover.transform;
            _chaseDistance = chaseDistance;
        }

        public override void Enter()
        {
            base.Enter();

            if (TargetDetector.TryGetTarget(out _target) == true)
            {
                View.StartRun();
                Mover.ChangeDirection(_target);
            }
            else
            {
                StateSwitcher.SwitchState<WaitingState>();
            }
        }

        public override void Exit()
        {
            base.Exit();

            _target = null;
        }

        public override void Update()
        {
            base.Update();

            if (Attacker.HasTargetInArea == true)
            {
                StateSwitcher.SwitchState<AttackState>();
            }
            else if (Mover.IsNeedChangeDirection == true || CanChaseTarget() == false)
            {
                StateSwitcher.SwitchState<WaitingState>();
            }
            else
            {
                Mover.MoveTo(_target);
            }
        }

        private bool CanChaseTarget()
        {
            if (_target == null || Vector2.Distance(_target.position, _transform.position) > _chaseDistance)
            {
                return false;
            }

            return true;
        }
    }
}