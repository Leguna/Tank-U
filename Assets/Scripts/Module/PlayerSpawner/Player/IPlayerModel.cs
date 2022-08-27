using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public interface IPlayerModel : IBaseModel
    {
        public string Name { get;  }
        public Vector3 Position { get; }
        public int Speed { get; }
        public int PlayerNumber { get; }
        public void SetPosition(Vector3 vector);
        public void SetSpeed(int i);
    }
}
