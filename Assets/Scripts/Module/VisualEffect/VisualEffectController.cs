using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.VisualEffect
{
    public class VisualEffectController : BaseController<VisualEffectController>
    {
        public void SpawnVisualEffect(VisualEffectCategory visualEffectCategory, Transform spawnTransform)
        {
            GameObject spawnObject = null;
            switch (visualEffectCategory)
            {
                case VisualEffectCategory.None:
                    Debug.Log("Visual Effect Category is None");
                    break;
                case VisualEffectCategory.Explosion:
                    spawnObject = Resources.Load<GameObject>("Prefabs/HUD/VisualEffect/SmallExplosion");
                    break;
                case VisualEffectCategory.Fire:
                    spawnObject = Resources.Load<GameObject>("Prefabs/HUD/VisualEffect/MediumFlames");
                    break;
                case VisualEffectCategory.MuzzleFlash:
                    spawnObject = Resources.Load<GameObject>("Prefabs/HUD/VisualEffect/MuzzleFlash");
                    break;
                case VisualEffectCategory.Trail:
                    spawnObject = Resources.Load<GameObject>("Prefabs/HUD/VisualEffect/TankTrail");
                    break;
                default:
                    Debug.Log("There's no such VisualEffectCategory");
                    break;
            }

            if (spawnObject != null)
                 spawnObject = Object.Instantiate(spawnObject, spawnTransform);
             if (visualEffectCategory != VisualEffectCategory.Trail)
                Object.Destroy(spawnObject, 3f);
        }
    }
}