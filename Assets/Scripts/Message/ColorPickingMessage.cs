using System.Collections.Generic;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Message
{
    public struct ColorPickingMessage
    {
        public ColorPickingMessage(PickingState pickingState, List<Color> pickedColorList)
        {
            PickingState = pickingState;
            PickedColorList = pickedColorList;
        }

        public PickingState PickingState { get; }
        public List<Color> PickedColorList { get; }
    }
}