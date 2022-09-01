using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using TankU.Module.PlayerSpawner.Player;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerSpawnerModel : BaseModel, IPlayerSpawnerModel
    {
        public List<int> ColorList { get; private set; }
        public List<bool> PlayerDeathList { get; private set; }
        public bool IsPlaying { get; private set; }

        public void SetPlayerDeathList(List<bool> playerDeathList)
        {
            PlayerDeathList = playerDeathList;
        }

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

        public List<int> GetPlayerLeft =>
            (from t in PlayerControllerList where t.Model.Health > 0 select t.Model.PlayerNumber).ToList();


        public PlayerSpawnerModel()
        {
            PlayerDeathList = new List<bool>();
            PlayerView = Resources.Load<PlayerView>("Prefabs/Player/tankFutureBody").GetComponent<PlayerView>();
            SpawnerTransform = new List<Transform>();
            PlayerControllerList = new List<PlayerController>();

            MaterialList = new List<Material>
            {
                Resources.Load<Material>("Materials/Tank/blue"),
                Resources.Load<Material>("Materials/Tank/red"),
                Resources.Load<Material>("Materials/Tank/green"),
                Resources.Load<Material>("Materials/Tank/yellow"),
                Resources.Load<Material>("Materials/Tank/black"),
                Resources.Load<Material>("Materials/Tank/white"),
                Resources.Load<Material>("Materials/Tank/purple"),
                Resources.Load<Material>("Materials/Tank/brown")
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

        public void AddPlayerDeath(int objPlayerIndex)
        {
            PlayerLeft--;
            SetDataAsDirty();
        }

        public void SetColorList(List<int> ints)
        {
            ColorList = ints;
            SetDataAsDirty();
        }
    }
}