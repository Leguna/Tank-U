using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using TankU.Module.Bomb;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombPoolModel : BaseModel, IBombPoolModel
    {
        public Transform Position { get; private set; }
        public List<BombController> BombControllers { get; }
        public int PoolSize { get; }
        public BombView BombView { get; }

        public BombPoolModel()
        {
            BombControllers = new List<BombController>();
            PoolSize = 2;
            BombView = Resources.Load<BombView>("Prefabs/Bombs/BombView");
        }

        public void AddBomb(BombController bombController)
        {
            BombControllers.Add(bombController);
            SetDataAsDirty();
        }

        public BombController GetObjectController() =>
    BombControllers.FirstOrDefault(bombController => bombController.Model.IsDeath);

    }
}
