using Agate.MVC.Base;
using TankU.Message;

namespace TankU.Module.Base
{
    public class MatchHistoryConnector : BaseConnector
    {
        private MatchHistoryController _matchHistoryController;

        protected override void Connect()
        {
            Subscribe<OnAddMatchMessage>(OnAddMatch);
            Subscribe<ShowMatchHistoryMessage>(_matchHistoryController.ShowView);
        }

        private void OnAddMatch(OnAddMatchMessage obj)
        {
            _matchHistoryController.AddMatch(obj.Winner, obj.ListColorIndex, obj.LevelList);
            //_gameplayLauncher.GameOver(obj.Winner, obj.ListColorIndex);
        }

        protected override void Disconnect()
        {
            Unsubscribe<OnAddMatchMessage>(OnAddMatch);
            Unsubscribe<ShowMatchHistoryMessage>(_matchHistoryController.ShowView);
        }
    }
}