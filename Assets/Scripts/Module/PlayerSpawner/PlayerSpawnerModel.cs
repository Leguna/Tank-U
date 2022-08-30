using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TankU.Module.PlayerSpawner.Player;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerSpawnerModel : BaseModel, IPlayerSpawnerModel
    {
        public bool IsPlaying { get; private set; }

        public void SetPlaying(bool value)
        {
            IsPlaying = value;
        }

        public List<Transform> SpawnerTransform { get; private set; }
        public List<PlayerController> PlayerControllerList { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public List<Material> MaterialList { get; private set; }
        public List<Material> MaterialPlayerSelected { get; private set; }
        public int DeathCount { get; private set; }
        public PlayerSpawnerModel()
        {
            PlayerView = Resources.Load<PlayerView>("Prefabs/Player/TankView").GetComponent<PlayerView>();
            SpawnerTransform = new List<Transform>();
            PlayerControllerList = new List<PlayerController>();

            MaterialList = new List<Material>
            {
                Resources.Load<Material>("Materials/Tank/blue"),
                Resources.Load<Material>("Materials/Tank/red"),
                Resources.Load<Material>("Materials/Tank/green"),
                Resources.Load<Material>("Materials/Tank/yellow")
            };
        }

        public void SetSpawnerTransform(List<Transform> position)
        {
            SpawnerTransform = position;
            SetDataAsDirty();
        }
    }
}