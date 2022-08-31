using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TankU.Gameplay
{
    public class HUDView : BaseView
    {
        [SerializeField] public List<BarStruct> barList;
        [SerializeField] public List<GameObject> Healthbar;
        [HideInInspector] public GameObject barItem;

        private void Start()
        {
            barItem = Resources.Load<GameObject>("Prefabs/HUD/Baritem");
            initBar(5);
        }

        public void initBar(int amount)
        {
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j < amount; j++)
                {
                    GameObject obj = Instantiate(barItem, Healthbar[i].transform);
                    obj.SetActive(false);
                    barList[i].Bar.Add(obj.transform);
                }
            }
        }
    }
}
