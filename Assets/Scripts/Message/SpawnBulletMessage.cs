using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct SpawnBulletMessage
    {
        public Transform TransformSpawner { get; }

        public SpawnBulletMessage(Transform tr)
        {
            TransformSpawner = tr;
        }

    }
}