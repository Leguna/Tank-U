using Agate.MVC.Base;
using TankU.MainMenu;
using TankU.Module.MatchHistory;
using TankU.Setting;

namespace TankU.Main
{
    public class MainView : BaseSceneView
    {
        public MainMenuView _mainMenuView;
        public SettingView _settingView;
        public MatchHistoryView _matchHistoryView;
    }
}