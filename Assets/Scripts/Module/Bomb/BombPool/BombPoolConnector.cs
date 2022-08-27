using Agate.MVC.Base;
using TankU.Message;

namespace TankU.Module.Bomb
{
    public class BombPoolConnector : BaseConnector
    {
        private BombPoolController _bombPoolController;
        
        protected override void Connect()
        {
            Subscribe<SpawnBombMessage>(_bombPoolController.SpawnBomb);
        }

        protected override void Disconnect()
        {
            Unsubscribe<SpawnBombMessage>(_bombPoolController.SpawnBomb);
        }
    }
}
