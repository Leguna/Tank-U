using System.Collections.Generic;
using TankU.Module.Base;

namespace TankU.Message
{
    public struct ColorPickingMessage
    {
        public ColorPickingMessage(PickingState pickingState, List<int> pickedColorIndex)
        {
            PickingState = pickingState;
            PickedColorIndex = pickedColorIndex;
        }

        public PickingState PickingState { get; }
        public List<int> PickedColorIndex { get; }
    }
}