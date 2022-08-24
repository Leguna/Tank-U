using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public interface IBombModel : IBaseModel
    {
        public int Damage { get; }
    }
}
