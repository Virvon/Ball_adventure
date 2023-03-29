using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector2 _currentTargetPosition;

    public event Action TargetPositionChanged;

    public Vector2 TargetPosition => _target.position;

    private void Start()
    {
        _currentTargetPosition = _target.position;
    }

    private void Update()
    {
        if(_currentTargetPosition != new Vector2(_target.position.x, _target.position.y))
        {
            TargetPositionChanged?.Invoke();
            
            _currentTargetPosition = _target.position;
        }
    }

    public void Move(Vector3 Position)
    {
        transform.position = Position;
    }
}
