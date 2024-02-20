namespace PlayerState
{
    public class CastSpellState : PlayerBaseState
    {
        private Spell _spell;
        private PlayerMover _mover;
        public CastSpellState(IStateSwitcher stateSwitcher, Player.Components components) : base(stateSwitcher, components)
        {
            _spell = components.Spell;
            _mover = components.Mover;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartCastSpell();
            _mover.StopMove();
            
            _spell.Cast();
            _spell.Casted += OnSpellCasted;
        }

        public override void Exit()
        {
            base.Exit();

            _spell.StopCast();
            _spell.Casted -= OnSpellCasted;
        }

        private void OnSpellCasted()
        {
            StateSwitcher.SwitchState<ReturnState>();
        }
    }
}