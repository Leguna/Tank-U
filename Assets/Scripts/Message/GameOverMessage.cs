using System.Collections.Generic;

namespace TankU.Message
{
    public struct GameOverMessage
    {
        public GameOverMessage(List<int> listColorIndex, int winner)
        {
            ListColorIndex = listColorIndex;
            Winner = winner;
        }

        public List<int> ListColorIndex { get; }
        public  int Winner { get; }
    }
}