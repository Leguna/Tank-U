using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TankU.Module.Base;
using TankU.Module.PlayerSpawner.Player;
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
        }

        public void SpawnPlayerStart()
        {
            for (int i = 0; i < _view.PLayerAmountSpawner; i++)
            {
                SpawnPlayer(i);
            }
        }
        // set color
        public void SetColorPlayer(List<Color> obj)
        {
            for (int i = 0; i <= (_view.PLayerAmountSpawner); i++)
            {
                if (obj[i] == Color.cyan)
                {
                     _model.MaterialList[i] =_model.MaterialList[0];
                }
                else if (obj[i] == Color.red)
                {
                    _model.MaterialList[i] = _model.MaterialList[1];
                }
                else if (obj[i] == Color.green)
                {
                    _model.MaterialList[i] = _model.MaterialList[2];
                }
                else if (obj[i] == Color.red)
                {
                    _model.MaterialList[i] = _model.MaterialList[3];
                }


            }
        }

        public void GetColorPlayer(List<Color> colorListPlayer, PickingState picikingState)
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
            var playerView = GameObject.Instantiate(_model.PlayerView, _view._spawnTransform[i]);
            playerController.Init(playerModel, playerView);
            InjectDependencies(playerController);
            _model.PlayerControllerList.Add(playerController);

        }

    }
}