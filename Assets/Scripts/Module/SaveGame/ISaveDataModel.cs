using Agate.MVC.Base;

namespace SpacePlan.Module.SaveGame
{
    public interface ISaveDataModel : IBaseModel
    {
        public int Coin { get; }
    }
}