using Agate.MVC.Base;

namespace TankU.Module.Bomb
{
    public interface IBombModel : IBaseModel
    {
        public int Damage { get; }
    }
}
