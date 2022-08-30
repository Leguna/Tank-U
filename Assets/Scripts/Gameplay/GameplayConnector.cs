using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.PlayerSpawner;
using TankU.PowerUp;

namespace TankU.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private PlayerSpawnerController _playerSpawner;
        private PowerUpPoolerController _powerUpSpawnerController;

        private void OnMoveInput(InputMoveMessage message)
        {
            if (_playerSpawner.Model.PlayerControllerList.Count > 0)

                _playerSpawner.Model.PlayerControllerList[message.PlayerNumber]
                    .OnMove(message.Direction, message.PlayerNumber);
        }

        private void OnRotatedInput(InputRotateMessage message)
        {
            if (_playerSpawner.Model.PlayerControllerList.Count > 0)
                _playerSpawner.Model.PlayerControllerList[message.PlayerNumber]
                    .OnRotate(message.Direction, message.PlayerNumber);
        }

        private void OnFire(FireMessage message)
        {
            if (_playerSpawner.Model.PlayerControllerList.Count > 0)
                _playerSpawner.Model.PlayerControllerList[message.PlayerNumber].OnFire(message.PlayerNumber);
        }

        private void OnBomb(BombMessage message)
        {
            if (_playerSpawner.Model.PlayerControllerList.Count > 0)

                _playerSpawner.Model.PlayerControllerList[message.PlayerNumber].OnBomb(message.PlayerNumber);
        }

        protected override void Connect()
        {
            Subscribe<InputMoveMessage>(OnMoveInput);
            Subscribe<InputRotateMessage>(OnRotatedInput);
            Subscribe<FireMessage>(OnFire);
            Subscribe<BombMessage>(OnBomb);
            Subscribe<TimerCountDownMessage>(_powerUpSpawnerController.OnStart);
        }

        protected override void Disconnect()
        {
            Unsubscribe<InputMoveMessage>(OnMoveInput);
            Unsubscribe<InputRotateMessage>(OnRotatedInput);
            Unsubscribe<FireMessage>(OnFire);
            Unsubscribe<BombMessage>(OnBomb);
            Unsubscribe<TimerCountDownMessage>(_powerUpSpawnerController.OnStart);
        }
    }
}