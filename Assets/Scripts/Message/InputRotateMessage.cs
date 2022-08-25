using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public struct InputRotateMessage
    {
        public Vector2 Direction { get; }

        public InputRotateMessage(Vector2 dir)
        {
            Direction = dir;
        }
    }
}
