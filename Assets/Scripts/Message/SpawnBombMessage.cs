using UnityEngine;

namespace TankU.Message
{
    public struct BombSpawnMessage
    {
        public Transform TransformSpawner { get; }

        public BombSpawnMessage(Transform tr)
        {
            TransformSpawner = tr;
        }
    }
}