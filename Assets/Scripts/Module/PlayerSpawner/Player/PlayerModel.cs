using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerModel : BaseModel, IPlayerModel
    {
        public string Name { get;  set; }
        public Vector3 Position { get; set; } = new Vector3(0, 0.3f, 0);
        public int Speed { get; set; }
        public int Health { get; private set; }
        public int PlayerNumber { get; private set; }

        //
        public Vector3 Velocity { get; protected set; }
        public Vector2 RotateDirec { get; protected set; }
        public Transform Head { get; protected set; }

        public Material MaterialColor { get; private set; }

        public PlayerModel()
        {
            Speed = 10;
            Name = "player";
            Health = 5;
        }

        public PlayerModel(int playerNumber, Material material) : this()
        {
            PlayerNumber = playerNumber;
            Debug.Log($"player number :{PlayerNumber}");
            MaterialColor = material;
        }

        public void SpawnPlayer(Vector3 position, Vector2 direction)
        {
            Position = position;
            RotateDirec = direction;
        }

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


        //

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

        //

        public virtual void Rotate(Vector2 rotate)
        {
            SetRotateDirec(rotate);
            SetDataAsDirty();
        }

        public void SetRotateDirec(Vector2 rotateDirec)
        {
            RotateDirec = rotateDirec;
            SetDataAsDirty();
        }

        //

        public void SetHead(Transform transform)
        {
            Head = transform;
            SetDataAsDirty();
        }
    }
}
