﻿using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.SaveGame;
using SpacePlan.Module.SoundFx;
using TankU.Message;

namespace TankU.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private SaveDataController _saveData;
        private SoundFxController _soundFx;
        private PlayerController _player;

        public void OnUpdateCoin(UpdateCoinMessage message)
        {
            _saveData.OnUpdateCoin(message.Coin);
            _soundFx.OnUpdateCoin();
        }

        private void OnMoveInput(InputMoveMessage message)
        {
            _player.OnMove(message.Direction);
        }

        private void OnRotatedInput(InputRotateMessage message)
        {
            _player.OnRotate(message.Direction);
        }

        private void OnFire(FireMessage message)
        {
            _player.OnFire();
        }

        protected override void Connect()
        {
            Subscribe<UpdateCoinMessage>(OnUpdateCoin);
            Subscribe<InputMoveMessage>(OnMoveInput);
            Subscribe<InputRotateMessage>(OnRotatedInput);
            Subscribe<FireMessage>(OnFire);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateCoinMessage>(OnUpdateCoin);
            Unsubscribe<InputMoveMessage>(OnMoveInput);
            Unsubscribe<InputRotateMessage>(OnRotatedInput);
            Unsubscribe<FireMessage>(OnFire);
        }
    }
}