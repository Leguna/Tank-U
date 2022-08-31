using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct PlayerStatusMessage 
    {
        public int HealtPoint { get; }
        public bool PowerUpStatus { get; }

        public PlayerStatusMessage(int healthPoint, bool powerUpStatus)
        {
            HealtPoint = healthPoint;
            PowerUpStatus = powerUpStatus;
        }
    }
}
