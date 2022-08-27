using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
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
