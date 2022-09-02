using UnityEngine;

namespace TankU.Message
{
    public struct BombExplodeMessage 
    {
        public Transform TransformSpawner { get; }

        public BombExplodeMessage(Transform transform)
        {
            TransformSpawner = transform;
        }
    }
}
