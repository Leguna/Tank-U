using System.Collections.Generic;
using UnityEngine;

namespace TankU.Module.Base
{
    public static class BaseColor
    {
        public static readonly List<Color> PlayerColors = new()
        {
            Color.cyan,
            Color.red,
            Color.green,
            Color.yellow,
            Color.black,
            Color.white,
            new Color(85, 10, 138),
            new Color(150, 75, 0)
        };
    }
}