using Agate.MVC.Base;
using TankU.Message;
using TankU.Gameplay;

namespace TankU.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private PlayerSpawnerController _playerSpawner;

        private void OnMoveInput(InputMoveMessage message)
        {
            _playerSpawner.Model.PlayerControllerList[message.PlayerNumber]
                .OnMove(message.Direction, message.PlayerNumber);
        }

        private void OnRotatedInput(InputRotateMessage message)
        {
            _playerSpawner.Model.PlayerControllerList[message.PlayerNumber]
                .OnRotate(message.Direction, message.PlayerNumber);
        }

        private void OnFire(FireMessage message)
        {
            _playerSpawner.Model.PlayerControllerList[message.PlayerNumber].OnFire(message.PlayerNumber);
        }

        private void OnBomb(BombMessage message)
        {
            _playerSpawner.Model.PlayerControllerList[message.PlayerNumber].OnBomb(message.PlayerNumber);
        }

        protected override void Connect()
        {
            Subscribe<InputMoveMessage>(OnMoveInput);
            Subscribe<InputRotateMessage>(OnRotatedInput);
            Subscribe<FireMessage>(OnFire);
            Subscribe<BombMessage>(OnBomb);
        }

        protected override void Disconnect()
        {
            Unsubscribe<InputMoveMessage>(OnMoveInput);
            Unsubscribe<InputRotateMessage>(OnRotatedInput);
            Unsubscribe<FireMessage>(OnFire);
            Unsubscribe<BombMessage>(OnBomb);
        }
    }
}