using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Gameplay;
using TankU.Message;
using TankU.Module.Base;
using TankU.Module.PlayerSpawner.Player;
using UnityEngine;

namespace TankU.Module.PlayerSpawner
{
    public class PlayerSpawnerController : ObjectController<PlayerSpawnerController,
        PlayerSpawnerModel, IPlayerSpawnerModel, PlayerSpawnerView>
    {
        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }

        public override void SetView(PlayerSpawnerView view)
        {
            base.SetView(view);
            _model.SetSpawnerTransform(_view._spawnTransform);
            SpawnPlayerStart();
        }

        public void StartPlay() => _model.SetPlaying(true);

        public void StopPlay() => _model.SetPlaying(false);

        public void SpawnPlayerStart()
        {
            for (int i = 0; i < _view.PLayerAmountSpawner; i++)
            {
                SpawnPlayer(i);
            }
        }

        public void SetColorPlayer(List<int> obj)
        {
            _model.SetColorList(obj);
            for (int i = 0; i < _model.PlayerControllerList.Count; i++)
            {
                _model.PlayerDeathList.Add(false);
                _model.PlayerControllerList[i].ChangeMaterial(_model.MaterialList[obj[i]]);
                _model.PlayerControllerList[i].ShowPlayer();
            }
        }

        public void GetColorPlayer(List<int> colorListPlayer, PickingState picikingState)
        {
            if (picikingState == PickingState.Finish)
            {
                SetColorPlayer(colorListPlayer);
            }
        }

        public void SpawnPlayer(int i)
        {
            var playerModel = new PlayerModel(i, _model.MaterialList[i]);
            var playerController = new PlayerController();
            var playerView = Object.Instantiate(_model.PlayerView, _view._spawnTransform[i]);
            playerController.Init(playerModel, playerView);
            InjectDependencies(playerController);
            _model.PlayerControllerList.Add(playerController);
            _model.AddPlayerLeft();
        }

        public void OnGameStart()
        {
            _model.SetPlaying(true);
            foreach (var playerController in _model.PlayerControllerList)
            {
                playerController.SetCanMove(true);
            }
        }

        public void OnGameStop()
        {
            _model.SetPlaying(false);
            foreach (var playerController in _model.PlayerControllerList)
            {
                playerController.SetCanMove(false);
            }
        }

        public void PlayerDeath(int objPlayerIndex)
        {
            _model.PlayerDeathList[objPlayerIndex] = true;
            _model.AddPlayerDeath(objPlayerIndex);

            for (int i = 0; i < _model.PlayerDeathList.Count; i++)
            {
                if (_model.PlayerDeathList[i] == false)
                {
                    Publish(new GameOverMessage(_model.ColorList, i));
                }
            }
        }
    }
}