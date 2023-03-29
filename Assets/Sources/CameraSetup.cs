using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BallAdventure.Model;

public class CameraSetup : MonoBehaviour
{
    [SerializeField] private CameraMovement _view;

    private IPresenter _presenter;
    private CameraModel _model;

    private void Awake()
    {
        _model = new CameraModel();
        _presenter = new CameraPresenter(_view, _model);
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
