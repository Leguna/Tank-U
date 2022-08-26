using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TankU.Boot;
using TankU.Module.Bullet;
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

        // TODO @Leguna: Remove this after finish bullet spawner
        private BulletController _bulletController;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new TimerController(),
                new ColorPickerController(),
                // TODO @Leguna: Remove this after finish bullet spawner
                new BulletController(),
                new ColorPickerController(),
                new PowerUpPoolerController(),
                new PowerUpController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _timerController.SetView(_view.TimerView);
            _colourPickerController.SetView(_view.ColorPickerView);
            _powerUpPooler.SetView(_view.powerUpPooler);
            _bulletController.SetView(_view.BulletView);
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