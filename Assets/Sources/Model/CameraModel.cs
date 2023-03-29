using System;
using UnityEngine;

namespace BallAdventure.Model
{
    public class CameraModel
    {
        private Vector3 _offset = new Vector3(0, 3.5f, -1);

        public event Action PositionChanged;

        public Vector3 Position { get; private set; }

        public void Move(Vector2 targetPosition)
        {
            Position = new Vector3(targetPosition.x, 0, 0) + _offset;

            PositionChanged?.Invoke();
        }
    }
}
