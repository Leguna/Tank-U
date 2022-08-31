using Agate.MVC.Base;
using System;
using TankU.Message;

namespace TankU.Module.Base
{
    public class MatchHistoryConnector : BaseConnector
    {
        
        
        protected override void Connect()
        {
            Subscribe<GameOverMessage>(OnGameOverMessage);

        }

        private void OnGameOverMessage(GameOverMessage obj)
        {
            //_gameplayLauncher.GameOver(obj.Winner, obj.ListColorIndex);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(OnGameOverMessage);

        }
    }
}
