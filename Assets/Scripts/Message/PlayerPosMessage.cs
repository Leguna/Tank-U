using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct PlayerPosMessage 
    {
        public PlayerPosMessage(Transform pos)
        {
            Position = pos;
        }

        public Transform Position { get; }
    }
}
