using Agate.MVC.Base;

namespace SpacePlan.Module.SaveGame
{
    public class SaveDataModel : BaseModel,ISaveDataModel
    {
        public int Coin { get; private set; }

        public void SetCoinData(int coin)
        {
            Coin = coin;
            SetDataAsDirty();
        }
    }
}