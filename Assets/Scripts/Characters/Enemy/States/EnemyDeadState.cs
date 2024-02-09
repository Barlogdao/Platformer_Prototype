namespace EnemyStates
{
    public class EnemyDeadState : IState
    {
        private readonly EnemyView _view;
        private readonly PlayerMover _mover;

        public EnemyDeadState(EnemyView view)
        {
            _view = view;
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