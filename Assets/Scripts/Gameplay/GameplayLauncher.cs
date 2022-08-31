using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TankU.Boot;
using TankU.Message;
using TankU.Module.Base;
using TankU.Module.Bomb;
using TankU.Module.BulletSpawner;
using TankU.Module.ColourPicker;
using TankU.Module.HUD;
using TankU.Module.PlayerSpawner;
using TankU.Module.PlayerSpawner.Player;
using TankU.Module.Result;
using TankU.Module.Timer;
using TankU.Module.VisualEffect;
using TankU.PowerUp;
using TankU.Setting;
using TankU.Sound;

namespace TankU.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";

        private SoundController _soundController;
        private TimerController _timerController;
        private ColorPickerController _colourPickerController;
        private PowerUpPoolerController _powerUpPooler;
        private PlayerInputController _playerInputController;
        private PlayerSpawnerController _playerSpawnerController;
        private BulletSpawnerController _bulletSpawnerController;
        private BombPoolController _bombPoolController;
        private HUDController _hudController;
        private VisualEffectController _visualEffectController;
        private ResultController _resultController;
        private SettingController _settingController;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector(),
                new BulletSpawnerConnector(),
                new BombPoolConnector(),
                new HUDConnector(),
                new VisualEffectConnector(),
                new PlayerSpawnerConnector(),
                new TimerConnector()
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new TimerController(),
                new ColorPickerController(),
                new PowerUpPoolerController(),
                new PowerUpController(),
                new PlayerInputController(),
                new BulletSpawnerController(),
                new BombPoolController(),
                new HUDController(),
                new VisualEffectController(),
                new PlayerSpawnerController(),
                new ResultController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _colourPickerController.SetView(_view.ColorPickerView);
            _powerUpPooler.SetView(_view.powerUpSpawner);
            _playerSpawnerController.SetView(_view.PlayerSpawnerView);
            _bulletSpawnerController.SetView(_view.bulletSpawnerView);
            _bombPoolController.SetView(_view.bombPoolView);
            _hudController.SetView(_view.HUDView);
            _settingController.SetView(_view.settingView);
            _timerController.SetView(_view.TimerView);
            _resultController.SetView(_view.resultView);
            _resultController.ShowTutorial();
            _resultController.SetCallbacks(BackToMainMenu, TryAgain, CloseTutorial);
            yield return null;
        }

        private void CloseTutorial()
        {
            _colourPickerController.StartPickingCharacter();
        }

        private void TryAgain()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        private void BackToMainMenu()
        {
            SceneLoader.Instance.LoadScene("MainMenu");
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        public void GameOver(int indexResult, List<int> objListColorIndex)
        {
            _timerController.HideView();
            _powerUpPooler.OnEndGame();
            _hudController.HideBar();
            _resultController.ShowResult(indexResult);
            Publish(new UpdateGameState(GameState.GameOver));
        }

        public void StartGame()
        {
            _timerController.OnStartGame();
            _soundController.PlayBgm(SoundBgmName.Game);
        }

        public void ResumeGame()
        {
            _timerController.OnGameResume();
            Publish(new UpdateGameState(GameState.Playing));
        }

        public void PauseGame()
        {
            _timerController.OnGamePause();
            Publish(new UpdateGameState(GameState.Pause));
        }

        public void AddPlayer()
        {
            _colourPickerController.AddColorPlayer(0);
        }

        public void StartPickingPlayer()
        {
            _colourPickerController.StartPickingCharacter();
            Publish(new UpdateGameState(GameState.PickingColor));
        }

        public void FinishPickingPlayer()
        {
            _colourPickerController.FinishPickingCharacter();
            Publish(new UpdateGameState(GameState.Playing));
        }

        public void CancelPickingPlayer()
        {
            _colourPickerController.CancelPickingCharacter();
        }
    }
}