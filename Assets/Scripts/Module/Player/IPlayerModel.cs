using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Gameplay
{
    public interface IPlayerModel : IBaseModel, IDamageableModel
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public int Speed { get; set; }


        public void SetPosition(Vector3 vector);
        public void SetSpeed(int i);
    }
}
