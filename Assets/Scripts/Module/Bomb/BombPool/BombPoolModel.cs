using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombPoolModel : BaseModel, IBombPoolModel
    {
        public Transform Position { get; private set; }

        public void SetPos(Transform pos)
        {
            Position = pos;
            SetDataAsDirty();
        }
    }
}
