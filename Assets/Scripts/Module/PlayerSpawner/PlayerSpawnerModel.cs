using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
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
        public int PlayerLeft { get; private set; }

        public List<int> GetPlayerLeft => (from t in PlayerControllerList where t.Model.Health > 0 select t.Model.PlayerNumber).ToList();

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

        public void AddPlayerLeft()
        {
            PlayerLeft++;
            SetDataAsDirty();
        }

        public void AddPlayerDeath()
        {
            PlayerLeft--;
            SetDataAsDirty();
        }
    }
}