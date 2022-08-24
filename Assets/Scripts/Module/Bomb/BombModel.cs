using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombModel : BaseModel, IBombModel
    {
        public int Damage { get; private set; }

        /* TODO @ Mark 
          public SetHP(int hp)
          {
          hp -= Damage;
          SetDataAsDirty();
         }
        */
        
    }
}
