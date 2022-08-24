using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.PowerUp
{
    public interface IPowerUpModel : IBaseModel
    {
        public float SpawnTimer { get; }
    }
}
