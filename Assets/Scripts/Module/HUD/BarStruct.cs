using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TankU.Gameplay
{
    [Serializable] public struct BarStruct
    {
        public Transform Bar;
        public List<Transform> BarItems;
        public Image Player;
    }
}