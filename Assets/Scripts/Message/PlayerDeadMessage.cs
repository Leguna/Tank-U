namespace TankU.Message
{
    public struct PlayerDeadMessage
    {
        public PlayerDeadMessage(int playerIndex)
        {
            PlayerIndex = playerIndex;
        }

        public int PlayerIndex { get; }
    }
}