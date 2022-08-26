using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct SpawnBulletMessage
    {
        public Transform transformSpawner { get; }

        public SpawnBulletMessage(Transform tr)
        {
            transformSpawner = tr;
        }

    }
}
