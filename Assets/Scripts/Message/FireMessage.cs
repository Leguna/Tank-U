using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{

    public struct FireMessage
    {
        public int PlayerNumber { get; }
        public FireMessage(int playerNumber) {
            PlayerNumber = playerNumber;
        }
    }
}
