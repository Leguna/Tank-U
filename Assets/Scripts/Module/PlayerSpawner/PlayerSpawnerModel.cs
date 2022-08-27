using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerSpawnerModel : BaseModel, IPlayerSpawnerModel
    {
        public List<Transform> SpawnerTransform { get; private set; }
        public List<PlayerController> PlayerControllerList { get; private set; }
        public PlayerView PlayerView { get; private set; }

        public PlayerSpawnerModel()
        {
            //Assets/Resources/Prefabs/TankView.prefab
            PlayerView = Resources.Load<PlayerView>("Prefabs/TankView").GetComponent<PlayerView>();
            SpawnerTransform = new List<Transform>();
            PlayerControllerList = new List<PlayerController>();
        }

        public void SetSpawnerTransform(List<Transform> position)
        {
            SpawnerTransform = position;
            SetDataAsDirty();
        }


    }
}
