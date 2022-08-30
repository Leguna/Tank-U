using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TankU.Module.PlayerSpawner.Player;
using UnityEngine;

namespace TankU.Gameplay
{
    public interface IPlayerSpawnerModel : IBaseModel
    {
        public List<Transform> SpawnerTransform { get; }
        public List<PlayerController> PlayerControllerList { get; }
        public PlayerView PlayerView { get; }
        public List<Material> MaterialList { get; }
        public List<Material> MaterialPlayerselected { get; }

        public void SetSpawnerTransform(List<Transform> position);
    }
}
