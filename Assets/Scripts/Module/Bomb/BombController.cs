using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombController : ObjectController<BombController, BombModel, IBombModel, BombView>
    {


        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }
    }
}
