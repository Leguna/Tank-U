using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TankU.Module.PlayerSpawner.Player;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerSpawnerModel : BaseModel, IPlayerSpawnerModel
    {
        public List<Transform> SpawnerTransform { get; private set; }
        public List<PlayerController> PlayerControllerList { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public List<Material> MaterialList { get; private set; }
        public List<Material> MaterialPlayerselected { get; private set; }

        public PlayerSpawnerModel()
        {
            PlayerView = Resources.Load<PlayerView>("Prefabs/Player/TankView").GetComponent<PlayerView>();
            SpawnerTransform = new List<Transform>();
            PlayerControllerList = new List<PlayerController>();

            MaterialList = new List<Material>();
            MaterialList.Add(Resources.Load<Material>("Materials/Tank/blue"));
            MaterialList.Add(Resources.Load<Material>("Materials/Tank/red"));
            MaterialList.Add(Resources.Load<Material>("Materials/Tank/green"));
            MaterialList.Add(Resources.Load<Material>("Materials/Tank/yellow"));
        }

        public void SetSpawnerTransform(List<Transform> position)
        {
            SpawnerTransform = position;
            SetDataAsDirty();
        }

    }
}