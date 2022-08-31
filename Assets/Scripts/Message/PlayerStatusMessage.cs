using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct PlayerStatusMessage 
    {
        public int PlayerIndex { get; }
        public int HealthPoint { get; }
        public bool PowerUpStatus { get; }

        public PlayerStatusMessage(int healthPoint, bool powerUpStatus, int playerIndex)
        {
            HealthPoint = healthPoint;
            PowerUpStatus = powerUpStatus;
            PlayerIndex = playerIndex;
        }
    }
}