using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
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
            Debug.Log($"spawn amount = {_view.PLayerAmountSpawner}");
            SpawnPlayerStart();
        }

        public void SpawnPlayerStart()
        {
            for (int i = 0; i < _view.PLayerAmountSpawner; i++)
            {
                Debug.Log($"index spawn player = {i + 1}");
                SpawnPlayer(i);
            }
        }

        public void SpawnPlayer(int i)
        {
            var playerModel = new PlayerModel(i);
            var playerController = new PlayerController();
            var playerView = GameObject.Instantiate(_model.PlayerView, _view._spawnTransform[i]);
            playerController.Init(playerModel, playerView);
            InjectDependencies(playerController);
            _model.PlayerControllerList.Add(playerController);

        }

    }
}
