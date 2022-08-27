using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerModel : BaseModel, IPlayerModel
    {

        public string Name { get;  set; }
        public int Speed { get; set; }
        public int Health { get; protected set; }
        public bool PowerUpIsActive { get; protected set; }
        public float PowerUpDuration { get; protected set; }

        public Vector3 Position { get; set; } = new Vector3(0, 0.3f, 0);
        public Vector3 Velocity { get; protected set; }
        public Vector2 RotateDirec { get; protected set; }
        public Transform Head { get; protected set; }



        public void SetPosition(Vector3 vector)
        {
            Position = vector;
            SetDataAsDirty();
        }

        public void SetSpeed(int speed)
        {
            Speed = speed;
            SetDataAsDirty();
        }

        public virtual void Move(Vector3 moveVelocity)
        {
            SetVelocity(moveVelocity);
            SetDataAsDirty();
        }

        private void SetVelocity(Vector3 moveVelocity)
        {
            Velocity = moveVelocity;
            SetDataAsDirty();
        }

        public virtual void Rotate(Vector2 rotate)
        {
            SetRotateDirec(rotate);
            SetDataAsDirty();
        }

        private void SetRotateDirec(Vector2 rotateDirec)
        {
            RotateDirec = rotateDirec;
            SetDataAsDirty();
        }

        public void SetHead(Transform transform)
        {
            Head = transform;
            SetDataAsDirty();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            SetDataAsDirty();
        }

        public void SetDurationPowerUp(float duration)
        {
            PowerUpDuration = duration;
            SetDataAsDirty();
        }

        public void SetHealth(int health)
        {

        }
    }
}
