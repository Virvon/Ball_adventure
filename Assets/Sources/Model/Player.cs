using System;
using UnityEngine;

namespace BallAdventure.Model
{
    public class Player
    {
        private float _speed = 4;
        private float _jumpForce = 300;

        private Vector2 _moveDirection = new Vector2(1, 0);

        private bool _isGrounded;

        public event Action VelocityChanged;
        public event Action Jumped;

        public Vector2 Velocity => _moveDirection.normalized * _speed;
        public Vector2 JumpForce => -1 * Vector3.Cross(_moveDirection, new Vector3(0, 0, 1)).normalized * _jumpForce;

        public void Init()
        {
            VelocityChanged?.Invoke();
        }

        public void SetGrounded()
        {
            _isGrounded = true;

            VelocityChanged?.Invoke();
        }

        public void TryJump()
        {
            if (_isGrounded)
            {
                Jumped?.Invoke();
                _isGrounded = false;
            }
        }
    }
}
