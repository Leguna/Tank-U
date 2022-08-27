using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.Bomb;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombPoolController : ObjectController<BombPoolController, BombPoolModel, BombPoolView>
    {
        public override void SetView(BombPoolView view)
        {
            base.SetView(view);
            for (var i = 0; i < _model.PoolSize; i++)
            {
                AddObjectToPool();
            }
        }

        public void SpawnBomb(SpawnBombMessage message)
        {
            Debug.Log($"Bomb Deployed {message.TransformSpawner.position}");
            var bombController = _model.GetObjectController() ?? AddObjectToPool();
            bombController.SpawnBomb(message.TransformSpawner.position,
                1, 1);
        }

        private BombController AddObjectToPool()
        {
            var bombModel = new BombModel();
            var bombController = new BombController();
            var bombView = Object.Instantiate(_model.BombView, bombModel.SpawnPosition, Quaternion.identity, _view.transform);
            bombController.Init(bombModel, bombView);
            InjectDependencies(bombController);
            _model.AddBomb(bombController);
            return bombController;
        }
    }
}
