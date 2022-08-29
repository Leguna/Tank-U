using Agate.MVC.Base;
using UnityEngine;
using System.Collections.Generic;

namespace TankU.Module.Bomb
{
    public class BombPoolView : BaseView
    {
        //TODO Mark: bikin pooling baru


        private void OnDropBomb(GameObject bom)
        {
            // TODO Mark: ambil pos dari Player
            //bom pos = player pos
            
            bom.SetActive(true);
        }
    }
}
