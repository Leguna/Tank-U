using System.Collections.Generic;
using Agate.MVC.Base;
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
        public List<Material> MaterialPlayerSelected { get; }
        public void SetSpawnerTransform(List<Transform> position);
    }
}