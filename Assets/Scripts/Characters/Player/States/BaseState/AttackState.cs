using System;

namespace PlayerState
{
    public class AttackState : PlayerBaseState
    {
        private readonly PlayerAnimatorEvents _animatorEvents;
        private readonly PlayerMover _mover;
        private readonly Attacker _attacker;

        public AttackState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
            _animatorEvents = components.AnimatorEvents;
            _mover = components.Mover;
            _attacker = components.Attacker;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartAttack();
            _mover.StopMove();
            _animatorEvents.AttackHits += OnAttackHits;
            _animatorEvents.AttackEnded += OnAttackEnds;
        }

        public override void Exit()
        {
            base.Exit();

            _animatorEvents.AttackHits -= OnAttackHits;
            _animatorEvents.AttackEnded -= OnAttackEnds;
        }

        private void OnAttackEnds()
        {
            StateSwitcher.SwitchState<ReturnState>();
        }


        private void OnAttackHits()
        {
            _attacker.Hit();
        }
    }
}