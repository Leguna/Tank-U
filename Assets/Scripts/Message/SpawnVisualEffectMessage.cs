using TankU.Module.Base;
using UnityEngine;

namespace TankU.Message
{
    public struct SpawnVisualEffectMessage

    {
        public SpawnVisualEffectMessage(Transform spawnTransform, VisualEffectCategory visualEffectCategory)
        {
            SpawnTransform = spawnTransform;
            VisualEffectCategory = visualEffectCategory;
        }

        public Transform SpawnTransform { get; }
        public VisualEffectCategory VisualEffectCategory { get; }
    }
}