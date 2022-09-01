using System;
using System.Collections.Generic;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.LevelUp
{
    [Serializable]
    public class ListLevelUpData
    {
        public List<LevelUpData> LevelUpDataList = new();
    }
}