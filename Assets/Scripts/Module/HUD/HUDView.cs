using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Gameplay;
using TankU.Module.Base;
using UnityEngine;
using UnityEngine.UI;

namespace TankU.Module.HUD
{
    public class HUDView : BaseView
    {
        [SerializeField] public List<BarStruct> barList;
        [SerializeField] public GameObject option;

        public void AddBar(GameObject barItem, GameObject playerColor, int playerCount)
        {
            for (int i = 0; i < playerCount; i++)
            {
                var barPlayerColor = Instantiate(playerColor, barList[i].Bar);
                var listHealth = new List<Transform>();
                for (int j = 0; j < 5; j++)
                {
                    var health = Instantiate(barItem, Vector3.zero, Quaternion.identity, barList[i].Bar.transform);
                    listHealth.Add(health.transform);
                }

                var healthBar = barList[i] = new BarStruct
                    { Bar = barList[i].Bar, Player = barPlayerColor.GetComponent<Image>(), BarItems = listHealth };
                barList.Add(healthBar);
            }
        }

        public void ShowBar(int playerCount)
        {
            option.SetActive(true);
            for (int i = 0; i < playerCount; i++)
            {
                barList[i].Bar.gameObject.SetActive(true);
            }
        }

        public void SetPlayerColor(List<int> obj)
        {
            for (var i = 0; i <= obj.Count - 1; i++)
            {
                barList[i].Player.GetComponent<Image>().color = BaseColor.PlayerColors[obj[i]];
            }
        }

        public void SetHealth(int player, int health)
        {
            for (var i = 0; i < 5; i++)
            {
                barList[player].BarItems[i].gameObject.SetActive(i < health);
            }
        }
    }
}