using Agate.MVC.Base;
using Agate.MVC.Core;

namespace Leguna.ExampleMVC.Module.SaveGame
{
    public interface ISaveDataModel : IBaseModel
    {
        public int Coin { get; }
    }
}