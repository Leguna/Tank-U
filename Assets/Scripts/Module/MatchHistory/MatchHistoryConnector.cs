using Agate.MVC.Base;
using TankU.Message;

namespace TankU.Module.Base
{
    public class MatchHistoryConnector : BaseConnector
    {
        private MatchHistoryController _matchHistoryController;

        protected override void Connect()
        {
            Subscribe<GameOverMessage>(OnGameOverMessage);
            Subscribe<ShowMatchHistoryMessage>(_matchHistoryController.ShowView);
        }

        private void OnGameOverMessage(GameOverMessage obj)
        {
            _matchHistoryController.AddMatch(obj.Winner,obj.ListColorIndex);
            //_gameplayLauncher.GameOver(obj.Winner, obj.ListColorIndex);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(OnGameOverMessage);
            Unsubscribe<ShowMatchHistoryMessage>(_matchHistoryController.ShowView);
        }
    }
}