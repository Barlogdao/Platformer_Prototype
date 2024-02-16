namespace EnemyStates
{
    public class PatrolingState : EnemyBaseState
    {
        public PatrolingState(IStateSwitcher stateSwitcher, Enemy.Components components) : base(stateSwitcher, components)
        {
        }

        public override void Enter()
        {
            base.Enter();

            TryChangeDirection();
            View.StartRun();
        }

        public override void Update()
        {
            base.Update();

            if (Attacker.HasTargetInArea == true)
            {
                StateSwitcher.SwitchState<AttackState>();
            }
            else if (TargetDetector.IsDetected())
            {
                StateSwitcher.SwitchState<ChasingState>();
            }
            else if (Mover.IsNeedChangeDirection == true)
            {
                StateSwitcher.SwitchState<WaitingState>();
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            Mover.Move();
        }

        private void TryChangeDirection()
        {
            if (Mover.IsNeedChangeDirection == true)
            {
                Mover.ChangeDirection();
            }
        }
    }
}