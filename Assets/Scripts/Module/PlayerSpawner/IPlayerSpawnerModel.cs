using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public interface IPlayerSpawnerModel : IBaseModel
    {
        public List<Transform> SpawnerTransform { get; }
        public List<PlayerController> PlayerControllerList { get; }
        public PlayerView PlayerView { get; }

        public void SetSpawnerTransform(List<Transform> position);
    }
}
