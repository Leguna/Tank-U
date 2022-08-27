using UnityEngine;

namespace TankU.Message
{
    public struct SpawnBombMessage    
    {
        public Transform TransformSpawner { get; }

        public SpawnBombMessage(Transform tr)
        {
            TransformSpawner = tr;
        }
    }
}
