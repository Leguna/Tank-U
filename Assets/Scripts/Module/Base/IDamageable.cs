namespace TankU.Module.Base
{
    public interface IDamageableModel
    {
        int Health { get; }

        void TakeDamage(int damage);
    }

    public interface IDoingDamageModel
    {
        int Damage { get; }
    }

    public interface IDamageableView
    {
        void TakeDamage(IDoingDamageModel damageModel);
    }
}