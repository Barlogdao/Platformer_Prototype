namespace EnemyStates
{
    public class DeadState : IState
    {
        private readonly EnemyView _view;

        public DeadState(IStateSwitcher stateSwitcher, Enemy.Components components)
        {
            _view = components.View;
        }

        public void Enter()
        {
            _view.StartDeath();
        }

        public void Exit() { }

        public void FixedUpdate() { }

        public void Update() { }
    }
}