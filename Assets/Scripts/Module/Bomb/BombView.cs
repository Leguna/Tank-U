using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombView : ObjectView<IBombModel>
    {
        //TODO @Mark bikin jadi array
        
        [SerializeField] private float _explodeDelay = 4.0f;
        [SerializeField] private float _explodeDuration = 4.0f;

        private float timer1;
        private float timer2;

        [SerializeField] private GameObject Bomb1;
        [SerializeField] private GameObject Bomb2;

        protected override void InitRenderModel(IBombModel model)
        {
            transform.position = model.SpawnPosition;
        }

        protected override void UpdateRenderModel(IBombModel model)
        {
            
        }

        private void Start()
        {
            timer1 = 0;
            timer2 = 0;
        }

        private void Update()
        {
            if (Bomb1.activeInHierarchy)
            {
                timer1 += Time.deltaTime;
            }

            if(Bomb2.activeInHierarchy)
            {
                timer2 += Time.deltaTime;
            }

            if (timer1 >= _explodeDelay)
            {
                Explode(Bomb1);
            }

            if (timer2 >= _explodeDelay)
            {
                Explode(Bomb2);
            }
        }

        private void Explode(GameObject bom)
        {
            bom.GetComponent<MeshRenderer>().enabled = false;
            
            bom.transform.GetChild(0).gameObject.SetActive(true);
            bom.transform.GetChild(1).gameObject.SetActive(true);

            if (timer1 >= _explodeDelay + _explodeDuration || timer2 >= _explodeDelay + _explodeDuration)
            {
                bom.GetComponent<MeshRenderer>().enabled = true;
                
                bom.transform.GetChild(0).gameObject.SetActive(false);
                bom.transform.GetChild(1).gameObject.SetActive(false); ;
                bom.SetActive(false);

                if (bom == Bomb1) timer1 = 0;
                if (bom == Bomb2) timer2 = 0;
            }
        }
    }
}
