using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankU.Message;

namespace TankU.Module.Bomb
{
    public class BombController : ObjectController<BombController, BombModel, IBombModel, BombView>
    {
        public void Init(BombModel bombModel, BombView bombView)
        {
            SetView(bombView);
            _model = bombModel;
        }

        public override void SetView(BombView view)
        {
            //view.SetCallback(OnCollisionEnter, OnUpdate);
            base.SetView(view);
        }

        public void SpawnBomb(Vector3 transformSpawnerPosition, int damage, int health)
        {
            _model.SpawnBomb(transformSpawnerPosition, damage, health);
            var transform = _view.transform;
            transform.position = _model.SpawnPosition;
            _view.gameObject.SetActive(!_model.IsDeath);
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public void BombExplode()
        {
            Publish(new BombExplodeMessage());
            Debug.Log("bom explode message");
        }
    }
}
