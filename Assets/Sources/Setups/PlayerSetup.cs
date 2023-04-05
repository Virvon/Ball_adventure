using UnityEngine;
using BallAdventure.Model;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private PlayerMovement _view;

    private PlayerPresenter _presenter;
    private Player _model;

    private void Awake()
    {
        _model = new Player();
        _presenter = new PlayerPresenter(_view, _model);
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
