using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using TankU.Module.Bullet;
using UnityEngine;

namespace TankU.Module.BulletSpawner
{
    public class BulletSpawnerModel : BaseModel
    {
        public List<BulletController> BulletControllers { get; }
        public int PoolSize { get; }
        public BulletView BulletView { get; }

        public BulletSpawnerModel()
        {
            BulletControllers = new List<BulletController>();
            PoolSize = 4;
            BulletView = Resources.Load<BulletView>("Prefabs/Bullet/BulletView");
        }

        public void AddBullet(BulletController bulletController)
        {
            BulletControllers.Add(bulletController);
            SetDataAsDirty();
        }

        public BulletController GetObjectController() =>
            BulletControllers.FirstOrDefault(bulletController => bulletController.Model.IsDeath);
    }
}