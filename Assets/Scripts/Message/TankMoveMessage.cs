using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct TankMoveMessage
    {
        public Transform TransformSpawner { get; }

        public TankMoveMessage(Transform transform)
        {
            TransformSpawner = transform;
        }
    }
}
