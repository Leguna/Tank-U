using Agate.MVC.Base;

namespace TankU.Module.Bomb
{
    public class BombModel : BaseModel, IBombModel
    {
        public int Damage { get; private set; }

        /* TODO @ Mark 
          public SetHP(int hp)
          {
          hp -= Damage;
          SetDataAsDirty();
         }
        */
        
    }
}
