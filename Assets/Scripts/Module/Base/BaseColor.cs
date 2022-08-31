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
            new Color(85f / 255, 10f / 255f, 138 / 255f, 1),
            new Color(150f / 255f, 75f / 255f, 0f, 1)
        };
    }
}