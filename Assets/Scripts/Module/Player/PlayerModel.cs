using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerModel : BaseModel, IPlayerModel
    {

        public string Name { get;  set; }
        public Vector3 Position { get; set; } = new Vector3(0, 0.3f, 0);
        public int Speed { get; set; }


        public void SetPosition(Vector3 vector)
        {
            Position = vector;
            SetDataAsDirty();
        }

        public void SetSpeed(int speed)
        {
            Speed = speed;
            SetDataAsDirty();
        }
    }
}
