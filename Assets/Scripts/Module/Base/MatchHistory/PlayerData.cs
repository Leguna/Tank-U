using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Module.Base
{
    public class PlayerData : MonoBehaviour
    {
        public int PlayerIndex;
        public int WinCount;
        public ColorType colorType;

        public PlayerData(int index, int winCount, ColorType color)
        {
            PlayerIndex = index;
            WinCount = winCount;
            colorType = color;
        }
    }
}
