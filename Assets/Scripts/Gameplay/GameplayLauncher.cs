using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TankU.Boot;
using TankU.Module.BulletSpawner;
using TankU.Module.ColourPicker;
using TankU.Module.Timer;
using TankU.PowerUp;
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
        private PlayerController _playerController;
        private PlayerInputController _playerInputController;
        private BulletSpawnerController _bulletSpawnerController;
        private HUDController _hudController;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector(),
                new BulletSpawnerConnector(),
                new HUDConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new TimerController(),
                new ColorPickerController(),
                new ColorPickerController(),
                new PowerUpPoolerController(),
                new PowerUpController(),
                new PlayerController(),
                new PlayerInputController(),
                new BulletSpawnerController(),
                new HUDController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _timerController.SetView(_view.TimerView);
            _colourPickerController.SetView(_view.ColorPickerView);
            _powerUpPooler.SetView(_view.powerUpPooler);
            _playerController.SetView(_view.PlayerView);
            _bulletSpawnerController.SetView(_view.bulletSpawnerView);
            _hudController.SetView(_view.HUDView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            _soundController.PlayBgm(SoundBgmName.Game);
            yield return null;
        }

        public void StartGame()
        {
            _timerController.OnStartGame();
        }

        public void ResumeGame()
        {
            _timerController.OnGameResume();
        }

        public void PauseGame()
        {
            _timerController.OnGamePause();
        }

        public void AddPlayer()
        {
            _colourPickerController.AddColorPlayer(0);
        }

        public void StartPickingPlayer()
        {
            _colourPickerController.StartPickingCharacter();
        }

        public void FinishPickingPlayer()
        {
            _colourPickerController.FinishPickingCharacter();
        }

        public void CancelPickingPlayer()
        {
            _colourPickerController.CancelPickingCharacter();
        }
    }
}