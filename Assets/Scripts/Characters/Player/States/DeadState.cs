namespace PlayerState
{
    public class DeadState : IState
    {
        private readonly PlayerView _view;
        private readonly PlayerMover _mover;

        public DeadState(PlayerView view, PlayerMover mover)
        {
            _view = view;
            _mover = mover;
        }

        public void Enter()
        {
            _mover.StopMove();
            _view.StartDeath();
        }

        public void Exit() { }
        public void FixedUpdate() { }
        public void Update() { }
    }
}