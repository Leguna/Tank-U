using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct PlayerExplodeMessage
    {
        public Transform TransformSpawner { get; }

        public PlayerExplodeMessage(Transform transform)
        {
            TransformSpawner = transform;
        }
    }
}
