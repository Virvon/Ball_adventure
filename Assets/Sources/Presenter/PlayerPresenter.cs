using BallAdventure.Model;

public class PlayerPresenter : IPresenter
{
    private PlayerMovement _view;
    private Player _model;

    public PlayerPresenter(PlayerMovement view, Player model)
    {
        _view = view;
        _model = model;
    }

    public void OnEnable()
    {
        _model.VelocityChanged += OnVelocityChanged;
        _model.Jumped += OnJump;

        _view.GameStarted += OnGameStart;
        _view.Jumped += OnInputJump;
        _view.Grounded += OnGrounded;
    }

    public void OnDisable()
    {
        _model.VelocityChanged -= OnVelocityChanged;
        _model.Jumped -= OnJump;

        _view.GameStarted -= OnGameStart;
        _view.Jumped -= OnInputJump;
        _view.Grounded -= OnGrounded;
    }

    private void OnVelocityChanged()
    {
        _view.SetVelocity(_model.Velocity);
    }

    private void OnGameStart()
    {
        _model.Init();
    }

    private void OnGrounded()
    {
        _model.SetGrounded();
    }

    private void OnInputJump()
    {
        _model.TryJump();
    }

    private void OnJump()
    {
        _view.Jump(_model.JumpForce);
    }
}
