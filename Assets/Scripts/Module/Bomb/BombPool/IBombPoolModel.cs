using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public interface IBombPoolModel : IBaseModel
    {
        public Transform Position { get; }
    }
}
