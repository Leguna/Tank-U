using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.PlayerSpawner.Player;
using UnityEngine;

namespace TankU.Gameplay
{
    public interface IPlayerSpawnerModel : IBaseModel
    {
        List<Transform> SpawnerTransform { get; }
        List<PlayerController> PlayerControllerList { get; }
        PlayerView PlayerView { get; }
        List<Material> MaterialList { get; }
        List<Material> MaterialPlayerSelected { get; }
        void SetSpawnerTransform(List<Transform> position);
        int PlayerLeft { get; }
        List<int> GetPlayerLeft { get; }
        List<int> ColorList { get; }
        List<bool> PlayerDeathList { get; }
    }
}