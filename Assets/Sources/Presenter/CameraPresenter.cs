using BallAdventure.Model;

public class CameraPresenter : IPresenter
{
    private CameraMovement _view;
    private CameraModel _model;

    public CameraPresenter(CameraMovement view, CameraModel model)
    {
        _view = view;
        _model = model;
    }

    public void OnEnable()
    {
        _view.TargetPositionChanged += OnTargetMoved;
        _model.PositionChanged += OnCameraPositionChanged;
    }

    public void OnDisable()
    {
        _view.TargetPositionChanged -= OnTargetMoved;
        _model.PositionChanged -= OnCameraPositionChanged;
    }

    private void OnTargetMoved()
    {
        _model.Move(_view.TargetPosition);
    }

    private void OnCameraPositionChanged()
    {
        _view.Move(_model.Position);
    }
}
