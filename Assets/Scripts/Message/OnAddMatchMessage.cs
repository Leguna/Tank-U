namespace TankU.Message
{
    public struct OnAddMatchMessage
    {
        public OnAddMatchMessage(int winner, int[] listColorIndex, int[] levelList)
        {
            ListColorIndex = listColorIndex;
            Winner = winner;
            LevelList = levelList;
        }

        public int[] LevelList { get; }
        public int[] ListColorIndex { get; }
        public int Winner { get; }
    }
}