using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombPoolView : BaseView
    {
        [SerializeField] private GameObject Bomb1;
        [SerializeField] private GameObject Bomb2;

        private void OnDropBomb(GameObject bom)
        {
            // TODO Mark: ambil pos dari Player
            //bom pos = player pos
            
            bom.SetActive(true);
        }
    }
}
