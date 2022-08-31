namespace TankU.Message
{
    public struct UpdatePlayerHealth
    {
        public UpdatePlayerHealth(int health, int playerIndex)
        {
            Health = health;
            PlayerIndex = playerIndex;
        }

        int Health { get; }
        int PlayerIndex { get; }
    }
}