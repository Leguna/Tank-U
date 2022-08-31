using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct InputMoveMessage 

    {
        public Vector3 Direction { get; }
        public int PlayerNumber { get; }

        public InputMoveMessage(Vector3 dir, int playerNumber)
        {
            Direction = dir;
            PlayerNumber = playerNumber;
        }
    }
}
