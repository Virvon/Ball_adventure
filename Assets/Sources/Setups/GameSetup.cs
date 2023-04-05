using UnityEngine;
using BallAdventure.Model;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameView _view;

    private IPresenter _presenter;
    private GameModel _model;

    private void Awake()
    {
        _model = new GameModel();
        _presenter = new GamePresenter(_view, _model);
    }

    private void OnEnable()
    {
        _presenter.OnEnable();
    }

    private void OnDisable()
    {
        _presenter.OnDisable();
    }
}
