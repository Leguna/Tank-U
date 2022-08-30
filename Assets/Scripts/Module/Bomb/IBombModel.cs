using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public interface IBombModel : IBaseModel, IDoingDamageModel
    {
        Vector3 SpawnPosition { get; }
        void SetPosition(Vector3 pos);
    }
}
