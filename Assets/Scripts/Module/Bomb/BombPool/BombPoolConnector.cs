using Agate.MVC.Base;
using TankU.Message;

namespace TankU.Module.Bomb
{
    public class BombPoolConnector : BaseConnector
    {
        private BombPoolController _bombPoolController;
        
        protected override void Connect()
        {
            Subscribe<BombSpawnMessage>(_bombPoolController.SpawnBomb);
        }

        protected override void Disconnect()
        {
            Unsubscribe<BombSpawnMessage>(_bombPoolController.SpawnBomb);
        }
    }
}