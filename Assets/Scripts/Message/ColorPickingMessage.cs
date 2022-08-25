using System.Collections.Generic;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Message
{
    public struct ColorPickingMessage
    {
        public ColorPickingMessage(PickingState pickingState, List<Color> colorList)
        {
            PickingState = pickingState;
            ColorList = colorList;
        }

        public PickingState PickingState { get; }
        public List<Color> ColorList { get; }
    }
}