using Controls.Input;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerView _view;

    private GameInput _input;

    private void Awake()
    {
        _input = new GameInput();
        _view.Initialize();
        _mover.Initialize(_input, _view);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
