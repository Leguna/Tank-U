using System;

namespace TankU.Module.Base
{
    [Serializable]
    public class LevelUpData
    {
        public int Level;
        public int Exp;
        public int ExpToNextLevel;
        public float IncrementNextLevel;
        public PlayerInventory Inventory;

        public LevelUpData(int expToNextLevel, int exp, int level, float incrementNextLevel)
        {
            ExpToNextLevel = expToNextLevel;
            Exp = exp;
            Level = level;
            IncrementNextLevel = incrementNextLevel;
        }

        public LevelUpData()
        {
            Level = 1;
            Exp = 0;
            ExpToNextLevel = 500;
            IncrementNextLevel = 1f;
            Inventory = new PlayerInventory();
        }

        public bool AddExp(int exp)
        {
            Exp += exp;
            if (Exp <= ExpToNextLevel) return false;
            Level++;
            Exp -= ExpToNextLevel;
            ExpToNextLevel = (int)(ExpToNextLevel * IncrementNextLevel);
            return true;
        }
    }

    [Serializable]
    public class PlayerInventory
    {
        public int ColorUnlocked;
    }
}