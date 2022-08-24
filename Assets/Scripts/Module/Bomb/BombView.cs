using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombView : ObjectView<IBombModel>
    {
        [SerializeField] private float _explodeDelay = 4.0f;
        [SerializeField] private float _explodeDuration = 4.0f;

        private float timer;

        [SerializeField] private GameObject Bomb1;
        [SerializeField] private GameObject Bomb2;


        protected override void InitRenderModel(IBombModel model)
        {
            
        }

        protected override void UpdateRenderModel(IBombModel model)
        {
            
        }

        private void Start()
        {
            timer = 0;
        }

        private void Update()
        {
            timer += Time.deltaTime;

            if (timer >= _explodeDelay)
            {
                Explode();
            }
        }

        private void Explode()
        {
            //TODO @ Mark, turn on Explosion objects

            if(timer >= _explodeDelay + _explodeDuration)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
