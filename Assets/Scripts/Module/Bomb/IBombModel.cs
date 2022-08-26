using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public interface IBombModel : IBaseModel
    {
        public int Damage { get; }
        Vector3 SpawnPosition { get; }
        void SetPosition(Vector3 pos);
    }
}
