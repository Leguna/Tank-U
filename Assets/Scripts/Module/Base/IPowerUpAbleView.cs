namespace TankU.Module.Base
{
    public interface IPowerUpAbleView
    {
        void OnHealthPowerUp(int health);
        void OnBulletPowerUp(float duration);
    }
}