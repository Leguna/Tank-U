using System.Collections;
using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.Base;
using TankU.Sound;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombController : ObjectController<BombController, BombModel, IBombModel, BombView>
    {
        public void Init(BombModel bombModel, BombView bombView)
        {
            SetView(bombView);
            _model = bombModel;
        }

        public void OnCountTimer()
        {
            if (_view.gameObject.activeInHierarchy)
            {
                if (_model.SpawnTimer <= 0)
                {
                    _model.SetTimerSpawn(4f);

                    Explode(_view.gameObject);
                }

                if (_model.Duration <= 0)
                {
                    _model.SetDuration(5.5f);

                    DespawnExplosion(_view.gameObject);
                }


                    _model.DecreaseTimer();
            }
        }

        public override void SetView(BombView view)
        {
            view.SetCallback(OnCountTimer, OnUpdate);
            base.SetView(view);
            foreach (var explosionView in view._explosionView)
            {
                explosionView.SetCallback(OnTriggerExplosionEvent);
            }
        }

        private void OnTriggerExplosionEvent(Collider obj)
        {
            obj.TryGetComponent(out IDamageableView damageableView);
            if (damageableView != null)
            {
                damageableView.TakeDamage(_model);
            }
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

        public void OnUpdate(float deltaTime)
        {
            _model.OnUpdateTime(deltaTime);
        }

        public void Explode(GameObject bomb)
        {
            Publish(new BombExplodeMessage(bomb.transform));
            Publish(new PlaySoundEffectMessage(SoundEffectName.BombExplode));
            bomb.GetComponent<MeshRenderer>().enabled = false;
            bomb.transform.GetChild(0).gameObject.SetActive(true);
            bomb.transform.GetChild(1).gameObject.SetActive(true);

            /*if (_model.Duration <= 0)
            {
                bomb.GetComponent<MeshRenderer>().enabled = true;
                bomb.transform.GetChild(0).gameObject.SetActive(false);
                bomb.transform.GetChild(1).gameObject.SetActive(false);
                bomb.SetActive(false);

                _model.SetDuration(5f);
            }*/
        }

        public void DespawnExplosion(GameObject bomb)
        {
            bomb.GetComponent<MeshRenderer>().enabled = true;
            bomb.transform.GetChild(0).gameObject.SetActive(false);
            bomb.transform.GetChild(1).gameObject.SetActive(false);
            bomb.SetActive(false);
        }
    }
}