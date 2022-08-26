using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Message
{
    public struct PowerupBouncePickupMessage
    {
        public float Duration { get; }

        public PowerupBouncePickupMessage(float duration)
        {
            Duration = duration;
        }
    }
}
