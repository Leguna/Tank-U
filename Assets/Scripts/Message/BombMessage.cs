namespace TankU.Message
{

    public struct BombMessage
    {
        public int PlayerNumber { get; }
        public BombMessage(int playerNumber) {
            PlayerNumber = playerNumber;
        }
    }
}
