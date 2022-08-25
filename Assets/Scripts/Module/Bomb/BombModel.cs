using Agate.MVC.Base;

namespace TankU.Module.Bomb
{
    public class BombModel : BaseModel, IBombModel
    {
        public int Damage { get; private set; }

        public void SetDamage(int damage)
        {
            Damage = damage;
            SetDataAsDirty();
        }
        
        /* TODO @ Mark 
          public SetHP(int hp)
          {
          hp -= Damage;
          SetDataAsDirty();
         }
        */
        
    }
}
